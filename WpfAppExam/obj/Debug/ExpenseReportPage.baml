   M S B A M L   `   `   `  ����E  AWpfAppExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppExam
WpfAppExam  5      "    WpfAppExam.ExpenseReportPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WpfAppExam     5        N� Title$  ExpenseIt - View Expense��5	      .��5      � ��5   
   �� 5       �� ImageSource$ Images/logo_bank.jpg��6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��230 �6    � RowDefinitions 5   
   �� 5      $	��100��6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��1��6      headerTextStyle#��[  6    .��6I   Expense Report6Y   �� 5   
   $��1��6   $��1��6   $��	12,12,7,7q�6.   ���	#aa999999 �� CornerRadius$ 10��6X   �� 5   
   $��1��6   $��1��6   $��10q�6.   ���	#aaffffff$ 10��6Q   ._�5      �  � 	Resources 5        TypeTemplate �� XPath  AmountTemplate��%�   &	       &	 I     �� 5      .R�5      �� ��6    �� $ @ExpenseType��5      �� 5       .R�5!      �� ��6    �� $ @ExpenseAmount��5"      5#       5$      �� 5%      $
��Auto �6'   �� 5&       5(      �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      .+�5-      ��   
labelStyle#��[ 6   .��6<   
이름 :6B   �� 5.      -   5         ��Name$ lblName��5.      $��1��6)   #��[ 50      ��5/      �� $ @Name��50      �� 51      $��1��6   #��[ 6&   .��6J   
부서 :6P   �� 52      -   5        $ lblDepartment��52      $��1��6/   $��1��6<   #��[ 54      ��53      �� $ @Department��54      &   System.Windows.Controls.DataGrid  55      -   5        $��2��55      $��2��6(   $��5,5,5,15q�56        columnHeaderStyle   ColumnHeaderStyle# [ 58      
������ 	   RowBackground
	 ���� $��0q�5;      
   	RowHeight$
 25Q�5<         AutoGenerateColumns .     RowHeaderWidth$ 0Q�5?      ��57      �� $ Expense��   Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ 경비 유형��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 5J   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5K   )   �� $ @ExpenseType��  5L      $ 사용 금액��6-   $ 2* 5M   )    5N   )   �� $ @ExpenseAmount��5P      5Q      5R      5S      5U      