namespace TimeFunctions;

public class TimeUTC
{
    /// <summary>
    ///     Конвертирует время в UTC, при наличии таймзоны. При отсутствии, принимает в рассчёт локальную таймзону.
    /// </summary>
    public static DateTime ConvertToUtc(DateTime dt) =>
        dt switch
        {
            { Kind: DateTimeKind.Unspecified } d => DateTime
                .SpecifyKind(value: d, kind: DateTimeKind.Local)
                .ToUniversalTime(),
            {} d => d.ToUniversalTime()
        };

    /// <summary>
    ///     Конвертирует время в UTC, при наличии таймзоны. При отсутствии, принимает в рассчёт локальную таймзону.
    /// </summary>
    /// <param name="dt">Конвертируемое время. Если оказывается null, возвращается defaultValue</param>
    /// <param name="defaultValue">Дефолтное время. Считается, что находится УЖЕ в UTC</param>
    /// <returns></returns>
    public static DateTime ConvertToUtc(DateTime? dt, DateTime defaultValue) =>
        dt switch
        {
            null => defaultValue,
            { Kind: DateTimeKind.Unspecified } d => DateTime
                .SpecifyKind(value: d, kind: DateTimeKind.Local)
                .ToUniversalTime(),
            {} d => d.ToUniversalTime()
        };

    /// <summary>
    ///     Конвертирует время в UTC, при наличии таймзоны. При отсутствии, принимает в рассчёт локальную таймзону.
    /// </summary>
    /// <param name="dt">Конвертируемое время. Если оказывается null, возвращается null</param>
    /// <returns></returns>
    public static DateTime? ConvertToUtc(DateTime? dt) =>
        dt switch
        {
            null => null,
            { Kind: DateTimeKind.Unspecified } d => DateTime
                .SpecifyKind(value: d, kind: DateTimeKind.Local)
                .ToUniversalTime(),
            {} d => d.ToUniversalTime()
        };
}
