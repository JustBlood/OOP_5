   M S B A M L   `   `   `  ����H  DSixthPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SixthPracticeSixthPractice  5   	       SixthPractice.ThirdTask   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SixthPractice     5   	     � Title$  	ThirdTask��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��Testing��6   $��2��6"   $��Center=�66   $��50(�6S   �� 5   
   $
��Real��6   $��2��6   $��Center=�6/   $��50(�6L   �� 5   
   -   5         ��Name$
 file��5      $��2��6   $��20q�6,   $��Get String From file��68   $��20(�6W   6e   �� 5   
   -   5        $ db��5      $��1��6   $��2��6-   $��20q�6:   $��Get String From DB��6F   $��20(�6c   6q   �� 5   
   -   5        $ internet��5      $��2��6#   $��2��63   $��20q�6@   $��Get String From Internet��6L   $��20(�6o   6}   �� 5   
   $��1��6   .+�5      �� $��
Enter path��6   $��Center=�6)   6H   �� 5      -   5         ��Name$
 path��5      $��Center=�6$   $��20q�6A    �� TextWrapping$
 Wrap=�6M   $��
Enter path��6a   $��Center=�6s   $	��120��6�   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� $��Enter connection string��6   $��Center=�66   6U   �� 5       -   5        $ 
connString��5       $��Center=�6*   $��20q�6G   $
 Wrap=�6S   $��Enter connection string��6g   $��Center=�6�   $	��120��6�   5!      �� 5"   
   $��1��6   $��2��6"   .+�5#      �� $��
Enter path��6   $��Center=�6)   6H   �� 5$      -   5        $	 url��5$      $��Center=�6#   $��20q�6@   $
 Wrap=�6L   $��	Enter url��6`   $��Center=�6q   $	��120��6�   5%      � 5&   
   $��3��6   $��0��6    5'      �� 5(      $��1* �6#   �� 5)      $��1* �6#   .+�5+      �� -   5        $
 File��5+      $��Add to event��6#   $��15q�6:   6F   �� 5,      -   5        $ DelFile��5,      $��1��6&   $��Del from event��66   $��15q�6O   6[   5-      � 5.   
   $��3��6   $��1��6    5/      �� 50      $��1* �6#   �� 51      $��1* �6#   .+�53      �� -	   5        $ Db��53      $��Add to event��6!   $��15q�68   6D   �� 54      -
   5        $ DelDb��54      $��1��6$   $��Del from event��64   $��15q�6M   6Y   55      � 56   
   $��3��6   $��2��6    57      �� 58      $��1* �6#   �� 59      $��1* �6#   .+�5;      �� -   5        $ Internet��5;      $��Add to event��6'   $��15q�6>   6J   �� 5<      -   5        $ DelInternet��5<      $��1��6*   $��Del from event��6:   $��15q�6S   6_   5=      5>      5?      