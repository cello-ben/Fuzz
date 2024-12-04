using System.Data;

namespace Fuzz.Frontend
{
    public class Lexer
    {
        private string raw;
        public Lexer(string _raw)
        {
            raw = _raw;
        }
    }

    public class Token<T>
    {
        public enum _TokenType
        {
            TOK_LPAREN,
            TOK_RPAREN,
            TOK_LQUOT,
            TOK_RQUOT,
            TOK_INT_LIT,
            TOK_FLOAT_LIT,
            TOK_STR_LIT,
            TOK_FUNC,
            TOK_EQ,
            TOK_FZ_EQ,
            TOK_PLUS,
            TOK_MINUS,
            TOK_TIMES,
            TOK_DIV,
            TOK_MOD
            //TODO Do we need TOK_TYPE?
        }

        private _TokenType TokenType { get; }
        private T? contents { get; }

        public Token(_TokenType tokenType, T? _contents)
        {
            switch (tokenType)
            {
                case _TokenType.TOK_LPAREN:
                case _TokenType.TOK_RPAREN:
                case _TokenType.TOK_LQUOT:
                case _TokenType.TOK_RQUOT:
                case _TokenType.TOK_EQ:
                case _TokenType.TOK_FZ_EQ:
                case _TokenType.TOK_PLUS:
                case _TokenType.TOK_MINUS:
                case _TokenType.TOK_TIMES:
                case _TokenType.TOK_DIV:
                case _TokenType.TOK_MOD:
                    TokenType = tokenType;
                    break;
                default:
                    if (_contents == null)
                    {
                        throw new ArgumentNullException("This token type cannot be null.");
                    }
                    TokenType = tokenType;
                    contents = _contents;
                    break;
            }
        }
    }
}