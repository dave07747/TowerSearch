   M S B A M L   `   `   `  ����  TowerSearch    TowerSearch.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Tower Search     v3.1��5   	   $��618.488��6'   $	��600��68   $	��600��6D   $	��600��6S    � WindowStartupLocation$ CenterScreen=�5   	    � Left$	 200��6.   
 � Top$	 200��69    � WindowState$ 	Maximized=�6C    � 
ResizeMode$ NoResize=�5   	      MaterialDesignBody#���   5	   
   $��Medium"�5   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	    � Icon$ logo.ico��6i   ��5
   	   Z� .��5      � ���	#FF29A62E � ColumnDefinitions 5   
   �� 5      $	��32* �6   �� 5      $
��217* �6   �� 5      $	��48* �6   �� 5      $	��65* �6   �� 5      $
��232* �6    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $
��Auto �6   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      �� 5      .+�5!   
   �� -   5        	 ��Name$	 Search��5!      $��Search��6!   $��0q�62   $��5��6F   $��53.333(�6S   $��	15,10,5,0q�6z   
 � ToolTip$&
  Search for part location or name��6�   $��3��6�   $	��255��6�   ���	#FF1A3E1B���	#DDFFFFFF6�   �� 5"   
   -   5        $	 ViewLog��5"      $��View Log��6"   $��0q�65   $��6��6I   $��53.333(�6V   $��	15,0,5,10q�6   $H
 BView log of parts taken out, modify log, and access to admin panel��6�   $��3��6�   $	��255��6�   ���	#FF1A3E1B���	#DDFFFFFF6  �� 5#   
   -   5        $��Borrow��5#      $��3��6"   $��0q�62   $��5��6F   $��53.333(�6S   $��	5,10,15,0q�6|   $
 Log a part out��6�   $��2��6�   $��Center=�6�   $	��255��6�   ���	#FF1A3E1B���	#DDFFFFFF6�   �� 5$   
   -   5        $��Return��5$      $��3��6"   $��0q�62   $��6��6F   $��53.333(�6S   $��	5,0,15,10q�6|   $*
 $Return a part that you have borrowed��6�   $��2��6�   $	��255��6�   ���	#FF1A3E1B���	#DDFFFFFF6�   �� 5%   
   -   5        $��Return��5%      $��3��6"   $��0q�62   $��6��6F   $��53.333(�6S   $��	5,0,15,10q�6|   $*
 $Return a part that you have borrowed��6�   $��2��6�   $	��255��6�   ���	#FF1A3E1B���	#DDFFFFFF6�   ]� 5&   
   $��2��6   $��	0,0,0,286q�6(   $��6��6;   .+�5'      � $��Right=�6   $��Right=�6*   5(      5)      5*      5+      