   M S B A M L   `   `   `  ����E  AWpfAppChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppChat
WpfAppChat  5   	       WpfAppChat.ChatWind   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WpfAppChat     5   	   -   5          � Title$!  이모티콘 채팅 Ver 1.0��5	   	   $	��500��6!   $	��300��6.   $	��300��6:   $	��300��6J   .��5
      ]�  � 	Resources 5   
    �� 
TargetType �� Property �� Value�� 5      %�   '��       'J� �     �� 5      " ��6   .�5      ��  � ��$ 5q�6/   �� 5       � ��$
 10,5q�60   �� 5       � ��$	 130��61   5      �� 5      " J�6   .�5      ��  �@��Margin$ 0q�6/   5      5      .+�5   
   �� $��옵션��6   $	��Top=�6   $	��Top=�64   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5         ��Name$ btnStart��5      $��서버 시작��6/   6?   �� 5      -   5        $ 
btnConnect��5      $��서버 연결��61   6A   5      ]� 5      .+�5      �� $��서버 아이피:��6   �� 5      -   5         ��Name$ tbxIP��5      $��5q�6-   68   5       5!      5"      �� 5#   
   -   5         ��Name$ 
sbarStatus��5#      $��Bottom=�6(   $��5��6@   $��0,5,0,0q�6N   .@�5$      �� .��5%      �� -   5        	 ��Name$	 tbkCurrentStatus��5%      5&      5'      �� 5(   
   -   5        
 ��Name$
 	rtbxInput��5(      $��Bottom=�6)   $��5q�6A   6L   �� 5)   
   $ 
Horizontal=�6   $��Bottom=�6.   $��Center=�6F   $��Center=�6a   .+�5*      �� -   5        $ btnFont��5*      $��폰트��6&   63   �� 5+      -	   5        $ btnEmoticon��5+      $��이모티콘��6*   69   5,      �� 5-   
   -
   5        $
 rtbxInfo��5-      $��5q�6(    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6E   5.      5/      