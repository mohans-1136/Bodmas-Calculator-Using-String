using System;
namespace Demo {
	class Calculator{
		static void Main(string[] args) {
			string str = "88*6-9+8/2-10";
			string output = calculate(calculate(calculate(calculate(str, '/'), '*'), '+'), '-');
			Console.WriteLine(output);
			//function
			static string calculate(string str, char op) {
				string firstText = "", secondText = "", replacedStrFirst = "", replacedStrSecond = "",
					            remFirstStr = "", remSecStr = "", firstNumText = "", SecondNumText = "", output = "";
				double firstNum = 0, secondNum = 0, result = 0;
				if(str.IndexOf(op, 1) != -1) {
					firstText = str.Substring(0, str.IndexOf(op,1));
					//Substr(Display, Index(Display, Operation) , Length(Display) - Index(Display, Operation) - 1)
					secondText = str.Substring(str.IndexOf(op) +1, str.Length - str.IndexOf(op)-1);
					replacedStrFirst = firstText.Substring(0,1)+((((firstText.Substring(1)).Replace("+", "$")).Replace("-", "$")).Replace("*", "$")).Replace("/", "$");
					replacedStrSecond = (((secondText.Replace("+", "$")).Replace("-", "$")).Replace("*", "$")).Replace("/", "$");
					if (op == '+' || op == '-')
                    {
						if (replacedStrFirst.LastIndexOf("$") != -1)
							firstNumText = firstText.Substring(replacedStrFirst.LastIndexOf("$"), replacedStrFirst.Length - replacedStrFirst.LastIndexOf("$") );
						else
							firstNumText = replacedStrFirst;
					}
					else
                    {
						if (replacedStrFirst.LastIndexOf("$") != -1)
							firstNumText = firstText.Substring(replacedStrFirst.LastIndexOf("$") + 1, replacedStrFirst.Length - replacedStrFirst.LastIndexOf("$") - 1);
						else
							firstNumText = replacedStrFirst;
					}
					
					if (replacedStrSecond.IndexOf("$") != -1)
						SecondNumText = secondText.Substring(0, replacedStrSecond.IndexOf("$"));
					else
						SecondNumText = secondText;
					firstNum = Convert.ToDouble(firstNumText);
					secondNum = Convert.ToDouble(SecondNumText);
                    switch(op) {
						case '+': result=firstNum + secondNum; break;
						case '-': result = firstNum - secondNum; break;
						case '*': result = firstNum * secondNum; break;
						case '/': result = firstNum / secondNum; break;
						default : result = 0; break;
                    }
					if (replacedStrFirst.LastIndexOf("$") != -1)
						remFirstStr=firstText.Substring(0, replacedStrFirst.LastIndexOf("$"));
                    if (replacedStrSecond.IndexOf("$") != -1)
                        remSecStr=secondText.Substring(replacedStrSecond.IndexOf("$"), replacedStrSecond.Length - replacedStrSecond.IndexOf("$"));
					if (op == '+' || op == '-')
                    {
						if (result < 0)
							str = remFirstStr + result + remSecStr;
						else
							str = remFirstStr + "+" + result + remSecStr;
					}
					else
                    {
						if (replacedStrFirst.IndexOf("$") != -1)
							str = remFirstStr + firstText.Substring(replacedStrFirst.LastIndexOf("$"), 1) + result + remSecStr;
						else
							str = remFirstStr + result + remSecStr;
					}
					output = str;
				}
				output = str;
				if (str.IndexOf(op, 1) != -1)  return calculate(str, op);
				else  return str;//recursion
			}
		}
	}	
}