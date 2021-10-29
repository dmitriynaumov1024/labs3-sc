/********************* STRUCTURAL LANGUAGE
Program:
SEQ
    Initialize:
    SEQ
        M:= 0
        N:= 0
        P:= 1
    END
    Open input file
    Process input file:
    REP For each line in Input file
        Process line:
        SEQ 
            Initialize:
            SEQ
                N:= 0
                M:= M + 1
            END
            Process numbers:
            REP For each number in line
                Process a number:
                CHOICE number < 0
                    P:= P * number
                    N:= N + 1
                ELSE
                    N:= N + 1
                END
            END
        END
    END
    Close input file
    Write to output file:
    SEQ
        Open output file
        Write M
        Write N
        Write P
        Write end of line
        Close output file
    END
    Stop execution
END.
**************************************/

using System;
using System.IO;
using System.Text;

class Program 
{
    // Global constants
    static readonly string 
        InputFilePath = "input.txt", OutputFilePath = "output.txt";
        
    static readonly char[] 
        whitespaceOrTab = new[]{ ' ', '\t' };
        
    static readonly StringSplitOptions 
        noEmptyEntries = StringSplitOptions.RemoveEmptyEntries;
    
    // Entry point
    static void Main()
    {
        int M = 0, N = 0;
        long P = 1;
        
        string[] inputData = File.ReadAllLines(InputFilePath);
        
        foreach (string line in inputData)
        {
            if (line.Trim().Length < 1) continue;
            
            M = M + 1;
            N = 0;
            
            foreach (string s in line.Split(whitespaceOrTab, noEmptyEntries))
            {
                long a = long.Parse(s);
                if (a < 0) P = P * a;
                N = N + 1;
            }
        }
        
        string outputData = String.Format("{0} {1} {2} \n", M, N, P);
        File.WriteAllText(OutputFilePath, outputData);
    }
}
