   M S B A M L   `   `   `  ����E  AWpfAppExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WpfAppExam
WpfAppExam  5          WpfAppExam.ExpenseItHome   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:WpfAppExam     5        N� Title$  ExpenseIt - Home��5	      .��5      �  � 	Resources 5   
      expenseDataSource � XPath  nameItemTemplate �� XPath��%$  &	        &	 �    � 5      $ Expenses��68   .��5      �	�	<Expenses xmlns="">
                        <Person Name="홍길동" Department="기획팀">
                            <Expense ExpenseType="Launch" ExpenseAmount="50" />
                            <Expense ExpenseType="Transportation" ExpenseAmount="50" />
                        </Person>
                        <Person Name="고아라" Department="국제팀">
                            <Expense ExpenseType="Document Printing" ExpenseAmount="50" />
                            <Expense ExpenseType="Gift" ExpenseAmount="125" />
                        </Person>
                        <Person Name="정주리" Department="기술팀">
                            <Expense ExpenseType="Maggzine subscription" ExpenseAmount="50" />
                            <Expense ExpenseType="New machine" ExpenseAmount="600" />
                            <Expense ExpenseType="Software" ExpenseAmount="500" />
                        </Person>
                        <Person Name="윤이슬" Department="재무팀">
                            <Expense ExpenseType="Dinner" ExpenseAmount="100" />
                        </Person>
                    </Expenses>        5"      �� 5#      .R�5$      �� ��6   �� $ @Name��5%      5&       � ColumnDefinitions 5'   
   �� 5(      �� 5)      $	��230 �6    � RowDefinitions 5+   
   �� 5,      $	��100��6   �� 5-      $
��Auto �6   �� 5.      $
��Auto �6   �� 5/      ��51   
   �� 52       �� ImageSource$ Images/logo_bank.jpg��6   .+�54   
   �� $��1��6     headerTextStyle#��[ 6    .��6I   View Expense Report6^   �� 55   
   $��1��6   $��1��6!   $��35��6.    �� Padding$ 5q�6:   $��	10,0,10,0q�6F   ���#4E87D4 �� CornerRadius$ 5��6n   ._�56      �� $��Center=�6   
�������.��6B   Names6I   57      �� 58   
   -   5        	 ��Name$	 	lbxPeople��58      ���	#bbffffff#��[ 5;      $��	10,0,10,0q�5<      $��1��5=      $��2��6"   ��5:      �� 
 �� Source#
 [  $ Person��5?      �� 5@   
   -   5        $��1��5@      $��3��6!     buttonStyle#��[ 6.   .��6h   View6n   5A      5B      