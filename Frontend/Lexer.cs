using System.Data;
using Fuzz.Util.Exceptions;

namespace Fuzz.Frontend
{
    //TODO catch all exceptions and display all at once.
    public class Lexer
    {
        private string raw;
        private int idx = 0;
        private List<object> tokens { get; } //We will only have instances of Token in here, but we can't mix types in a list unless we use generic objects.
        public Lexer(string _raw)
        {
            raw = _raw;
            tokens = new();
        }

        public void ExtractNumericLiteral() //TODO refactor into two methods; one for returning a parsed int/float, one for creating & adding tokens to list.
        {
            //Check for float vs. int by way of presence of decimal point. TODO decide on allowing int for float.
            //Edge cases: multiple decimal points, trailing decimal point, leading decimal point.
            //OK: 0.7, not OK: .7
            string numericLiteralString = String.Empty;
            int decimalCount = 0;
            while (idx < raw.Length)
            {
                char c = raw[idx++];
                if (Char.IsDigit(c) || c != '.' || c == '-')
                {
                    switch (c)
                    {
                        case Char.IsDigit(c):
                            numericLiteralString += c;
                            break;
                        case '.':
                            numericLiteralString += c;
                            decimalCount++;
                            if (decimalCount > 1)
                            {
                                throw new InvalidNumericLiteralException("Cannot have multiple decimal points in a numeric literal.");
                            }
                            break;
                        case '-':
                            if (numericLiteralString.Length == 0)
                            {
                                numericLiteralString += c;
                                break;
                            }
                            else
                            {
                                throw new InvalidNumericLiteralException("Cannot have a negative sign inside of a numeric literal (prefix only).");
                            }
                        default:
                            break;

                    }
                }
                else
                {
                    break;
                }
            }
            if (numericLiteralString.Contains("."))
            {
                //TODO check for validity.
                bool canParse = float.TryParse(numericLiteralString, out float n);
                if (canParse)
                {
                    Token<object> token = new(Token<object>._TokenType.TOK_DATA_TYPE, null);
                    tokens.Add(token);
                    token = new(Token<object>._TokenType.TOK_FLOAT_LIT, n);
                    tokens.Add(token);
                }
            }
            else
            {
                bool canParse = int.TryParse(numericLiteralString, out int n);
                Token<object> token = new(Token<object>._TokenType.TOK_DATA_TYPE, null);
                tokens.Add(token);
                token = new(Token<object>._TokenType.TOK_INT_LIT, n);
                tokens.Add(token);
            }
            return;
        }

        public void Parse() //TODO bool for success, or just throw exception(s)?
        {
            
            while (idx < raw.Length)
            {
                char c = raw[idx];

                //idx++;
            }
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
            TOK_MOD,
            TOK_BW_AND,
            TOK_BW_OR,
            TOK_BW_XOR,
            TOK_LSHIFT,
            TOK_RSHIFT,
            TOK_BW_NOT,
            TOK_COMMA, //TODO implement multiple args
            TOK_RETURNS,
            TOK_DATA_TYPE,
            TOK_VAR_NAME,
            TOK_NEWLINE,
            TOK_CRLF
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
                case _TokenType.TOK_BW_AND:
                case _TokenType.TOK_BW_OR:
                case _TokenType.TOK_BW_XOR:
                case _TokenType.TOK_LSHIFT:
                case _TokenType.TOK_RSHIFT:
                case _TokenType.TOK_BW_NOT:
                case _TokenType.TOK_COMMA:
                case _TokenType.TOK_RETURNS:
                case _TokenType.TOK_NEWLINE:
                case _TokenType.TOK_CRLF:
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
