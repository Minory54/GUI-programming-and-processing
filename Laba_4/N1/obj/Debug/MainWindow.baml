   M S B A M L   `   `   `  ����=  9N1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:N1N1  5   	       N1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:N1     5   	     � Title$  Журнал��5   	   $	��450��6   $	��800��6%    � 	Resources 5
       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%�  'o�       '  J     '�� �     �� 5   
   " o�6   .�5      ��  � ��
 �����6>   5      �� 5   
   "  6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6>   �� 5       � �� �	#FFBEBEF16@   �� 5       � ��$	 2pxq�60   6>   �� 5       � ��$ 8,2,8,2q�6(   6:   5      5      .��5      � .+�5   
   �� -   5         ��Name$ btn_add��5      $��Добавить��6"   $��Right=�65   $	��Top=�6Q   6i     5   
   -   5          Name$ 
dg_Journal��5      $��0,24,0,0q�6'      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 №��6<   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *id+6<     5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   $	 ФИО��6N   
 6/   �� *
StudentFIO+6N     5      $	 Физика��6A   
 6%   �� *	Physics+6A     5       $	 Математика��6>   
 6%   �� *Math+6>   4  .System.Windows.Controls.DataGridTemplateColumn  5!         CellTemplate 5"      �� 5#      .R�5$      �� $ btn_edit��6%   -   5        $��Изменить��5$   7   6c   5%      5'        5(       5)      �� 5*      .R�5+      �� $ btn_del��6%   -   5        $��Удалить��5+   6   6`   5,      5.      50      �� 51   
   -   5        $ 
btn_Update��51      $��Обновить��6%   $
��Left=�68   $	��Top=�6S   6k   52      53      