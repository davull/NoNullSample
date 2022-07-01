using Unit = System.ValueTuple;

namespace OptionType.Monads
{
    // See https://github.com/la-yumba/functional-csharp-code/tree/master/LaYumba.Functional
    
    using static F;

    public static class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);

        public static Option.None None => Option.None.Default;
    }

    public struct Option<T> : IEquatable<Option.None>, IEquatable<Option<T>>
    {
        private readonly T _value;
        private readonly bool _isSome;
        private bool _isNone => !_isSome;

        private Option(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);

        public static implicit operator Option<T>(T value)
            => value is null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value) : None();

        public IEnumerable<T> AsEnumerable()
        {
            if (_isSome)
                yield return _value;
        }

        public bool Equals(Option<T> other)
            => _isSome == other._isSome &&
               (_isNone || _value!.Equals(other._value));

        public bool Equals(Option.None _) => _isNone;

        public static bool operator ==(Option<T> @this, Option<T> other) => @this.Equals(other);
        public static bool operator !=(Option<T> @this, Option<T> other) => !(@this == other);

        public override bool Equals(object? obj) => obj is Option<T> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(_value, _isSome);

        public override string ToString() => _isSome ? $"Some({_value})" : "None";
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value),
                        "Cannot wrap a null value in a 'Some'; use 'None' instead");

                Value = value;
            }
        }
    }

    public static class OptionExtensions
    {
        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> f)
            => optT.Match(
                None: () => None,
                Some: t => f(t));

        public static Option<R> Map<T, R>(this Option.None _, Func<T, R> f)
            => None;

        public static Option<R> Map<T, R>(this Option.Some<T> some, Func<T, R> f)
            => Some(f(some.Value));

        public static Option<R> Map<T, R>(this Option<T> optT, Func<T, R> f)
            => optT.Match(
                () => None,
                t => Some(f(t)));

        internal static bool IsSome<T>(this Option<T> @this)
            => @this.Match(
                None: () => false,
                Some: _ => true);

        internal static T ValueUnsafe<T>(this Option<T> @this)
            => @this.Match(
                () => throw new InvalidOperationException(),
                t => t);

        public static T GetOrElse<T>(this Option<T> opt, T defaultValue)
            => opt.Match(
                () => defaultValue,
                t => t);

        public static T GetOrElse<T>(this Option<T> opt, Func<T> fallback)
            => opt.Match(
                () => fallback(),
                t => t);

        public static Option<T> OrElse<T>(this Option<T> left, Option<T> right)
            => left.Match(
                () => right,
                _ => left);

        public static Option<T> OrElse<T>(this Option<T> left, Func<Option<T>> right)
            => left.Match(
                () => right(),
                _ => left);

        public static Option<R> Select<T, R>(this Option<T> @this, Func<T, R> func)
            => @this.Map(func);

        public static Option<T> Where<T>(this Option<T> optT, Func<T, bool> predicate)
            => optT.Match(
                () => None,
                t => predicate(t) ? optT : None);

        public static Option<RR> SelectMany<T, R, RR>(
            this Option<T> opt, Func<T, Option<R>> bind, Func<T, R, RR> project)
            => opt.Match(
                () => None,
                t => bind(t).Match(
                    () => None,
                    r => Some(project(t, r))));
    }
}