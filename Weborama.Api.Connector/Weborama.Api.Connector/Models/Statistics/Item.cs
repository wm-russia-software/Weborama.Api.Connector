namespace Weborama.Api.Connector.Models.Statistics
{
    /// <summary>
    /// Элемент
    /// </summary>
    public class Item
    {
        #region Свойства

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        internal Item(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion
    }
}
