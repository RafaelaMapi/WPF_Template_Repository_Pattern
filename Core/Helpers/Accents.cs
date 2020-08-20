// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Accents.cs" company="Gili Energy">
//   Copyright (c) 2019 All Rights Reserved
// </copyright>
// <summary>
//   Defines the Accents type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Core.Helpers
{
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// The accents.
    /// </summary>
    public static class Accents
    {

        #region Functions

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Remove(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        #endregion     


    }
}
