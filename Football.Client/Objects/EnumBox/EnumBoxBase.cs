namespace Football.Client.Objects.EnumBox
{
    /// <summary>
    /// Создано, для того, чтобы enum можно было проецировать в ComboBox a.k.a DropMenu
    /// </summary>
    public struct EnumBoxBase<T> where T : Enum
    {
        public string EnumName { get; set; }
        public T EnumValue { get; set; }


        public static IEnumerable<EnumBoxBase<T>> EnumToBoxedValues()
        {
            var collection = new List<EnumBoxBase<T>>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                collection.Add(new EnumBoxBase<T> { EnumName = item.ToString(), EnumValue = item });
            }

            return collection;
        }
    }
}
