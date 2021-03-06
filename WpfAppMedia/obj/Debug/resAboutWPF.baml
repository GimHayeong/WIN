   M S B A M L   `   `   `  ����F  BWpfAppMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppMediaWpfAppMedia  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   aboutWPF  0� Width 0� HorizontalAlignment J� Opacity �� 
LineHeight �� TextDecorations }� Location �� Orientation �� CellSpacing �� Padding	 � 	Resources
 �� 
TargetType �� Property �� Value � Color � Offset �� Columns �� 
ColumnSpan �� TextAlignment �� 
LineHeight �� BorderBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      #localclr-namespace:WpfAppMedia  5      %7  &	        /� 5      .T�5   
   J� $��22(�6   $
��Bold"�6"   .*�64   
Capter 16>   J� 5   
   $��35(�6   $
��Bold"�6"   .*�64   
Why WPF?6>   J� 5   
   .*�6   .*�5      .*�5   N   .*�5      0� $	  130��6   $ Right=�6"   .t�5      �� .r�5      �� $��Images/wpf.png��6   $ .9Q�64   5      5      �� In movies and on TV, the main characters are typically an exaggeration of the people you encounter in real life. They're more attractive, they react quicker, and they somehow always know exactly what to do. The same could be said about the software they use.5      J� 5   
   .*�6   ��This first struck me back in 1994 when watching the movie Disclosure, starring Michael Douglas, Demi Moore, and an email program that looks nothing like Microsoft Outlook! Throughout the movie, we're treated to various visual features of the program: a spinning three-dimensional "e," messages that unfold when you open them and crumple when you delete them, hints of inking support, and slick animations when you print messages. (The email program isn't even the most unrealistic software in the movie. I'll just say "virtual reality database" and leave it at that.)5      J� 5   
   .*�6   ��Usability issues aside, Hollywood has been telling us for a long time that software in the real world isn't as compelling as it should be. You can probably think of several examples on your own of TV shows and movies with comically unrealistic software. But real-world software is starting to catch up to Hollywood's standards! You can already see it in traditional operating systems (such as Mac OS and more recently Windows Vista), in software for devices such as TiVo or Xbox, and on the Web thanks to Adobe Flash. Users have increasing expectations for the experience of using software, and companies are spending a great deal of time and money on user interfaces that differentiate themselves from the competition.5      J� 5   
   .*�6   ��Microsoft now has a solution for helping people create 21st-century software that meets these high demands, using less time and less money. This solution is Windows Presentation Foundation (WPF).5!      �� 5"   
   $ 2��6   
�������
���   �.�5#      J� $��18(�6   .*�6&   .*�5$      �� .�6   WPF6   
 Unleashed5%      J� 5&      $��30(�6   $
��Bold"�6&   .*�68   .*�5'      �� .�6   Notes from Chapter 16/   5(      5)      J� 5*   
   .*�6   .*�5+      �� $��http://www.daum.net?�6   .�6:   Here6@    are some highlights of WPF:5,      �� 5-   
   .<�5.      �� .9�5/      J� .*�6   Broad integration6/   50      �� 51      .9�52      J� .*�6   Resolution independence65   53      �� 54      .9�55      J� .*�6   Hardware acceleration63   56      �� 57      .9�58      J� .*�6   Declarative programming65   59      �� 5:      .9�5;      J� .*�6   .*�5<      �� .�6    5>      }� $ Strikethrough=�6-   .�5?   0   $"Rich composition and customization5A      5B      5C      5D      �� 5E   
   .r�5F      (� .��5G      �� $ 
Horizontal=�6   .+�5H      �� $��Images/diagram.jpg��6   $��5q�68   �� 5I      $��Center=�6    $	��100��6;   $
��Wrap=�6G   -+The technologies in the .NET Framework 3.0.6�   5J      5K      5L      J� 5M   
   .*�6   42Here's another version of the diagram, as a Table:6H   �� 5N   
   $ 5��6   $ 15q�6    $��Segoe UI)�6-   	 5O      �� 5P      �� 5Q      '��       "
 ��6   .�5R      ��  �@��BorderBrush
 �   �68   �� 5S       �@��BorderThickness$ 2q�6<   �� 5T       � ��
 �����67   �� 5U       �@��TextAlignment$ Center=�6:   5V      5W      ��5Y      �� 5Z      .��5[      � $ Yellow��6#   $ 0Q�62   � 5\      $ Orange��6#   $ 1Q�62   5]       5_      �� 5`      �� 5a      �� 5b      �� 5c      .�5e      �� .�5f      �� .�5g      �� $ 4��6    $ Center=�5h       $ 50��5i       
������ 
 ���� .�5l      J� $
��Bold"�6$   .*�66   .NET Framework 3.06J   5m      5n      �� 5o      .�5p      �� $ 70��6    .�5q      J� $
��Bold"�6$   .*�66   WPF6;   5r      �� 5s      .�5t      J� $
��Bold"�6$   .*�66   WCF6;   5u      �� 5v      .�5w      J� $
��Bold"�6$   .*�66   WF6:   5x      �� 5y      .�5z      J� $
��Bold"�6$   .*�66   WCS6;   5{      5|      �� 5}      .�5~      �� .�5      J� $
��Bold"�6$   .*�66   	ADO.NET6?   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   	ASP.NET6?   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   Windows Forms6E   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   -69   5�      5�      �� 5�      .�5�      �� $ 4��6    $ Center=�6/   $ 30��6F   .�5�      J� $
��Bold"�6$   .*�66   .*�5�      �� Common Language Runtime�� 5�      5�      5�      5�      5�      5�      J� 5�   
   .*�6   .*�5�      ,*You can read more about this on my blog ( �� $0��*http://blogs.msdn.com/adam_nathan/rss.aspx?�6   .�6Q   	subscribe6\    �� 5�      .F�5�      �� $��14��6   $��Images/rss.gif��6#   5�      )' ), which I try to update once a month.5�      5�      5�      