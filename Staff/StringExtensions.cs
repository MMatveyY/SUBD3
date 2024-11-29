// <copyright file="StringExtensions.cs" company="Земсков Н.А и Моисеенко М.А">
// Copyright (c) Земсков Н.А и Моисеенко М.А. All rights reserved.
// </copyright>

namespace Staff
{
    public static class StringExtensions
    {
        /// <summary>
        /// Проверяет, является ли строка null или пустой.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        /// <returns>True, если строка null или пуста; иначе false.</returns>
        public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Обрезает строку и возвращает null, если строка пустая.
        /// </summary>
        /// <param name="value">Строка для обработки.</param>
        /// <returns>Обрезанная строка или null.</returns>
        public static string? TrimOrNull(this string value)
        {
            var trimmed = value?.Trim();
            return trimmed.IsNullOrEmpty() ? null : trimmed;
        }

        /// <summary>
        /// Форматирует строку в заглавные буквы для представления имен или названий.
        /// </summary>
        /// <param name="value">Строка для форматирования.</param>
        /// <returns>Строка с первым символом в верхнем регистре.</returns>
        public static string? Capitalize(this string? value)
        {
            if (value.IsNullOrEmpty())
                return null;

            value = value.Trim();
            return char.ToUpper(value[0]) + value[1..].ToLower();
        }
    }

    /// <summary>
    /// Расширения для работы с коллекциями.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Преобразует элементы коллекции в строку, объединяя их заданным разделителем.
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции.</typeparam>
        /// <param name="values">Коллекция значений.</param>
        /// <param name="separator">Разделитель.</param>
        /// <returns>Строка с объединенными значениями.</returns>
        public static string Join<T>(this IEnumerable<T> values, string separator = ", ")
        {
            return string.Join(separator, values);
        }
    }

    /// <summary>
    /// Расширения для работы с датами.
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Преобразует дату в человеко-читаемый формат (например, 12 ноября 2024).
        /// </summary>
        /// <param name="date">Дата для преобразования.</param>
        /// <returns>Форматированная дата.</returns>
        public static string ToHumanReadable(this DateTime date)
        {
            return date.ToString("dd MMMM yyyy");
        }
    }
}
