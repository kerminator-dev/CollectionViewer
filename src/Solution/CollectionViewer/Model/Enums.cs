namespace CollectionViewer.Model
{
    public class Enums
    {
        /// <summary>
        /// Символы границ
        /// </summary>
        public enum GridChars
        {
            TopLeftCorner = '╔',
            TopSeparator = '╦',
            TopRightCorner = '╗',
            CenterSeparator = '╬',
            RowSeparator = '═',
            ColumnSeparator = '║',
            BottomLeftCorner = '╚',
            BottomRightCorner = '╝',
            BottomSeparator = '╩',
            LeftSeparator = '╠',
            RightSeparator = '╣',
        }

        /// <summary>
        /// Выранивание по горизонтали
        /// </summary>
        public enum Align
        {
            Left,
            Center,
            Right,
        }
    }
}
