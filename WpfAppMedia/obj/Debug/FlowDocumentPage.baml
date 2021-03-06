   M S B A M L   `   `   `  ����F  BWpfAppMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppMediaWpfAppMedia  5      "    WpfAppMedia.FlowDocumentPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WpfAppMedia     5        N� Title$  FlowDocumentPage��5	      .��5      /� .T�5   
   J� $��22(�6   $
��Bold"�6"   .*�64   
Capter 16>   J� 5   
   $��35(�6   $
��Bold"�6"   .*�64   
Why WPF?6>   J� 5   
   .*�6   .*�5      .*�5   N   .*�5      0�  0� Width$	 130��6    0� HorizontalAlignment$ Right=�6"   .t�5      �� .r�5      �� $��Images/wpf.png��6    J� Opacity$ .9Q�64   5      5      �� In movies and on TV, the main characters are typically an exaggeration of the people you encounter in real life. They're more attractive, they react quicker, and they somehow always know exactly what to do. The same could be said about the software they use.5      J� 5   
   .*�6   ��This first struck me back in 1994 when watching the movie Disclosure, starring Michael Douglas, Demi Moore, and an email program that looks nothing like Microsoft Outlook! Throughout the movie, we're treated to various visual features of the program: a spinning three-dimensional "e," messages that unfold when you open them and crumple when you delete them, hints of inking support, and slick animations when you print messages. (The email program isn't even the most unrealistic software in the movie. I'll just say "virtual reality database" and leave it at that.)5"      J� 5#   
   .*�6   ��Usability issues aside, Hollywood has been telling us for a long time that software in the real world isn't as compelling as it should be. You can probably think of several examples on your own of TV shows and movies with comically unrealistic software. But real-world software is starting to catch up to Hollywood's standards! You can already see it in traditional operating systems (such as Mac OS and more recently Windows Vista), in software for devices such as TiVo or Xbox, and on the Web thanks to Adobe Flash. Users have increasing expectations for the experience of using software, and companies are spending a great deal of time and money on user interfaces that differentiate themselves from the competition.5%      J� 5&   
   .*�6   ��Microsoft now has a solution for helping people create 21st-century software that meets these high demands, using less time and less money. This solution is Windows Presentation Foundation (WPF).5(      �� 5)   
    �� 
LineHeight$ 2��6   
�������
���   �.�5*      J� $��18(�6   .*�6&   .*�5+      �� .�6   WPF6   
 Unleashed5,      J� 5-      $��30(�6   $
��Bold"�6&   .*�68   .*�5.      �� .�6   Notes from Chapter 16/   5/      50      J� 51   
   .*�6   .*�52      �� $��http://www.daum.net?�6   .�6:   Here6@    are some highlights of WPF:53      �� 54   
   .<�55      �� .9�56      J� .*�6   Broad integration6/   57      �� 58      .9�59      J� .*�6   Resolution independence65   5:      �� 5;      .9�5<      J� .*�6   Hardware acceleration63   5=      �� 5>      .9�5?      J� .*�6   Declarative programming65   5@      �� 5A      .9�5B      J� .*�6   .*�5C      �� .�6    �� TextDecorations 5E      }�  }� Location$ Strikethrough=�6-   .�5F   0   $"Rich composition and customization5H      5I      5J      5K      �� 5L   
   .r�5M      (� .��5N      ��  �� Orientation$ 
Horizontal=�6   .+�5O      �� $��Images/diagram.jpg��6   $��5q�68   �� 5P      $��Center=�6    $	��100��6;   $
��Wrap=�6G   -+The technologies in the .NET Framework 3.0.6�   5Q      5R      5S      J� 5T   
   .*�6   42Here's another version of the diagram, as a Table:6H   �� 5U   
    �� CellSpacing$ 5��6   	 �� Padding$	 15q�6    $��Segoe UI)�6-   
 � 	Resources
 5V       �� 
TargetType �� Property �� Value�� 5W      %�   '��       �� 5X      " ��6   .�5Y      ��  �@��BorderBrush
 �   �68   �� 5Z       �@��BorderThickness$ 2q�6<   �� 5[       � ��
 �����67   �� 5\       �@��TextAlignment$ Center=�6:   5]      5^      ��5`      �� 5a      .��5b      �  � Color$ Yellow��6#    � Offset$ 0Q�62   � 5c      $ Orange��6#   $ 1Q�62   5d       �� Columns 5f      �� 5g      �� 5h      �� 5i      �� 5j      .�5l      �� .�5m      �� .�5n      ��  �� 
ColumnSpan$ 4��6     �� TextAlignment$ Center=�5o        �� 
LineHeight$ 50��5p       
������  �� BorderBrush
 ���� .�5s      J� $
��Bold"�6$   .*�66   .NET Framework 3.06J   5t      5u      �� 5v      .�5w      �� $ 70��6    .�5x      J� $
��Bold"�6$   .*�66   WPF6;   5y      �� 5z      .�5{      J� $
��Bold"�6$   .*�66   WCF6;   5|      �� 5}      .�5~      J� $
��Bold"�6$   .*�66   WF6:   5      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   WCS6;   5�      5�      �� 5�      .�5�      �� .�5�      J� $
��Bold"�6$   .*�66   	ADO.NET6?   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   	ASP.NET6?   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   Windows Forms6E   5�      �� 5�      .�5�      J� $
��Bold"�6$   .*�66   -69   5�      5�      �� 5�      .�5�      �� $ 4��6    $ Center=�6/   $ 30��6F   .�5�      J� $
��Bold"�6$   .*�66   .*�5�      �� Common Language Runtime�� 5�      5�      5�      5�      5�      5�      J� 5�   
   .*�6   .*�5�   7   +)You can read more about this on my blog (�� $0��*http://blogs.msdn.com/adam_nathan/rss.aspx?�6A   .�6z   	subscribe6�   �� 6�   .F�6�   �� $��14��6�   $��Images/rss.gif��6�   6�   (&), which I try to update once a month.5�      5�      5�      