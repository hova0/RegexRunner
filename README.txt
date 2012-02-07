RegexRunner

It has been a long time since I worked on RegexRunner.   

You might think that this program will help you learn regular expressions.
It will not.  Why then does this program exist?  

Its main function is to transform text using regular expressions.  In Linux
the command line is king and sed,awk, and grep are the de-facto tools used
to transform text with regular expressions.  You might think that a simple
port of these utilities to Windows would achieve the same productivity.  This
is based on the faulty premise that the command line in Windows is equivalent
to the command line in Linux.

In Windows, copy+paste is king.  Which is how this program primarily receives
and transforms text.  The top textarea receives text via paste.  The result is 
put in the bottom area, for instant verification that the regex worked
correctly.  If it didn't then nothing is destructively lost, just fix it and
run it again.  

That's it.  That's all there is to this program.  

Now onto the features.
In addition to .NET standard regular expressions, there are a few additions.

"Case", "Multi Line", and "Single Line" function as per normal .NET regex.

"Match Mode" will discard all text NOT matched by the regex.  It will then perform
the standard replace function as normal.  This is primarily useful for matching
and transforming a few specific things when you are not interested in the rest
of the text.  

"Ingore Dups" requires "Match Mode" and will discard any output that matches
previous output.  



