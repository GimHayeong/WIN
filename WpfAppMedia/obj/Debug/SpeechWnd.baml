   M S B A M L   `   `   `  ����F  BWpfAppMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppMediaWpfAppMedia  5   	       WpfAppMedia.SpeechWnd   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppMedia     5   	   -   5          � Title$  	SpeechWnd��5	   	   $	��300��6   $	��600��6(   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6    � 	Resources 5       �� 
TargetType �� Property �� Value��%z   '��       �� 5      " ��6   .�5      ��  � ��$
 10,5q�60   �� 5       � ��$
 10,5q�6/   5      5      .+�5      �� -   5         ��Name$ cbxVoice��5      �� 5      -   5         ��Name$ tbxMsg��5      $	��100��6&   $��
I love WPF��65   �� 5      -   5        	 ��Name$	 btnSpeak��5      $��Speak��6'   67   �� 5      -   5        $	 	btnPrompt��5      $��PromptBuilder��6(   6@   �� 5      -   5        $	 btnSSML��5      $
��SSML��6&   65   �� 5      -   5        $	 btnText��5      $
��TEXT��6&   65   �� 5      -   5        $	 btnWPF��5      ��5      �� 5      $��20��6   $��Images/wpf.png��6'   5!      5"      �� 5$   
   -	   5        $ 	tbxResult��5$      $��1��6%   �� 5&   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   .+�5'      �� -
   5        $	 	btnRecord��5'      $	��REC��6(   66   5(      5)      5*      