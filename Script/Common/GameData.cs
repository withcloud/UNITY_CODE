using System.Collections;
using System.Collections.Generic;

public class GameData
{
    //所有的答案组,摩斯密码   
    public static string[][] answerMorseArray_StartScene = new string[5][] {
        new string[2]{ ".",".."},
        new string[1]{ "-"},
        new string[1]{ ".."},
        new string[1]{ "---"},
        new string[1]{ "-.-."}
    };
    public static string[][] answerMorseArray_QuestionScene;

    //所有的答案组,字母
    public static Dictionary<string, char> morse2CharDic = new Dictionary<string, char> { { ".-",'A'},{"-...",'B'},{ "-.-.",'C'},{ "-..",'D'}, { ".", 'E' }, { "..-.",'F'},
                                                                                          { "--.",'G' },{ "....",'H'},{"..",'I' },{".---",'J' },{ "-.-",'K'},{".-..",'L' },
                                                                                          { "--", 'M' },{ "-.", 'N' },{ "---", 'O' },{ ".--.", 'P' },{ "--.-", 'Q' },{ ".-.", 'R' },
                                                                                          { "...", 'S' },{ "-", 'T' },{ "..-", 'U' }, { "...-", 'V' },{ ".--", 'W' },{ "-..-", 'X' },
                                                                                          { "-.--", 'Y' },{ "--..", 'Z' },{ ".----", '1' },{ "..---", '2' },{ "...--", '3' },{ "....-", '4' },
                                                                                          { ".....", '5' },{ "-....", '6' },{ "--...", '7' },{ "---..", '8' },{ "----.", '9' },{ "-----", '0' },};
    public static char[][] answerCharArray_QuestionScene;

    public static void SetMorseArraies(ref string[][] morseAnswerArray, char code) {
        switch (code) {
            case 'S':
                morseAnswerArray = answerMorseArray_StartScene;
                break;
            case 'Q':
                morseAnswerArray = answerMorseArray_QuestionScene;
                break;
            default:
                break;
        }
    }

}
