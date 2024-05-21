# Asymptotic Analysis

## Sigma Notation Rules

### Summation Formulas

1. \(\sum\_{i=0}^{\infty} a^i = \frac{1}{1 - a}\) where \(|a| < 1\)
2. \(\sum\_{i=0}^{n} a^i = \frac{a^{n+1} - 1}{a - 1}\) where \(|a| > 1\)
3. \(\sum\_{i=0}^{n} i = \frac{n(n + 1)}{2}\)
4. \(\sum\_{i=0}^{n} i^2 = \frac{n(n + 1)(2n + 1)}{6}\)

## Important Notes

1. \((\log N)^a < N^b\) for large \(N\) where \(a\) and \(b\) are constants.
2. \(\sum\_{i=1}^{n} i^k = O(N^{k+1})\).

## Asymptotic Notations

- **O(): Upper Bound**  
  \(Cg(n) \geq F(n)\) where \(C\) is a constant.

- **Ω(): Lower Bound**  
  \(Cg(n) \leq F(n)\) where \(C\) is a constant.

- **θ(): Exact Bound**  
  \(C_1g(n) \leq F(n) \leq C_2g(n)\) where \(C_1\) and \(C_2\) are constants.

## Recurrence Equation

The general form of a recurrence equation is:
\[T(N) = O(\text{Non-recursive}) + T(\text{Recursive})\]

## Master Method

The Master Method is used to solve recurrences of the form:
\[T(N) = a T\left(\frac{N}{b}\right) + F(N), \quad T(\text{base}) = θ(1)\]
where \(a \geq 1\) and \(b > 1\).

**Master Method Cases:**

1. **Case 1:** If \(F(N) = O(N^c)\) where \(c < \log_b a\), then \(T(N) = θ(N^{\log_b a})\).
2. **Case 2:** If \(F(N) = θ(N^{\log_b a})\), then \(T(N) = θ(N^{\log_b a} \log N)\).
3. **Case 3:** If \(F(N) = Ω(N^c)\) where \(c > \log_b a\), then \(T(N) = θ(F(N))\).

![Master Method](https://raw.githubusercontent.com/BishoySedra/Algorithms_Course/main/Sheets/Analysis%20Sheet/Master_Method.png)

## Recursion Tree Solution Steps

1. **Calculate # Levels**: Trace input size.
2. **Calculate the Complexity of Each Level**.
3. **Calculate Complexity of Last Level**: Number of leaves \(\*\) \(T(\text{base})\).
4. **Sum the Complexity**: Sum the complexity of each level and the last level.
