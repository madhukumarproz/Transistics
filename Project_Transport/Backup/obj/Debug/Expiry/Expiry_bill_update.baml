   M S B A M L   `   `   `  ����L  HProject_Transport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TransportProject_Transport  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      *    $Project_Transport.Expiry_bill_update   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5      @d2http://schemas.microsoft.com/expression/blend/2008  	   5      1localclr-namespace:Project_Transport  	   5      7date&clr-namespace:System;assembly=mscorlib  	   5      .��5
      � $	��550��6   $��	0 100 0 0q�6   
�������  � ColumnDefinitions  5   
   �� 5      $	��625 �6   �� 5      $	��625 �6   .+�5   
   �� $��
VEHICLE NO��6   $��30��6%   $	��100��61   $��-150 -500 0 0q�6=   $��0��6T   �� 5   
   -   5        $��	vehicleno��5      $��30��6#   $	��150��6/   $��100 -500 0 0q�6;   {�.  $��0��6c   �� 5   
   $��EXPIRY TYPE��6   $��30��6&   $	��100��62   $��-150 -400 0 0q�6>   $��0��6U   �� 5   
   -   5        $
��type��5      $��30��6   $	��150��6*   $��100 -400  0 0q�66   {�.  $��0��6_   .��6o   5      �� 5   
   $
��FROM��6   $��30��6   $	��100��6+   $��-150 -300 0 0q�67   $��0��6N   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��from��5   A   
 �� Now   SelectedDate# Z 6   $��30��6M   $	��120��6Y   $��80 -300 0 0q�6e   $��0��6z   �� 5   
   $��TO��6   $��30��6   $	��100��6)   $��-150 -200 0 0q�65   $��0��6L     5   
   -   5        $��to��5   A   # Z 6   $��30��6K   $	��120��6W   $��80 -200 0 0q�6c   $��0��6x   �� 5   
   $��PAID AMOUNT��6   $��30��6&   $	��100��62   $��-150 -100 0 0q�6>   $��0��6U   �� 5   
   -   5        $��amount��5      $��30��6    $	��100��6,   $��60 -100 0 0q�68   $��0��6M   .��6]   ��5      �� 5       �� Path$ paidamnt�6    �� UpdateSourceTrigger$ PropertyChanged=�6*    �� Mode$ TwoWay=�6P    �� ValidatesOnDataErrors .  �� ValidationRules 5       "   Project_Transport.NumberOnly  5!      6-   5#      .��5$      5%      �� 5&   
   $��	PAID DATE��6   $��30��6$   $	��100��60   $��
-150 0 0 0q�6<   $��0��6P     5'   
   -   5        $��paiddate��5'   A   # Z 6   $��30��6Q   $	��120��6]   $��80 0 0 0q�6i   $��0��6{   �� 5(   
   $��NO��6   $��30��6   $	��100��6)   $��-150 100 0 0q�65   $��0��6K   �� 5)   
   -   5        $��no��5)      $��30��6   $	��100��6(   $��
60 100 0 0q�64   $��0��6H   .��6X   ��5*      �� 5+      $ no�6   $ PropertyChanged=�6$   $ TwoWay=�6J    .  5,        5-      6-   5/      .��50      51      �� 52   
   -   5        $��ok��52      $��OK��6   $��30��6(   $��60��64   $��-200 200 0 0q�6?   $��0��6f   �� 53   
   -	   5        $
��back��53      $
��BACK��6   $��30��6,   $��60��68   $��
10 200 0 0q�6C   $��0��6j   �� 54   
   -
   5        $��delete��54      $��DELETE��6   $��30��60   $��60��6<   $��200 200 0 0q�6G   $��0��6q   &   System.Windows.Controls.DataGrid  55   
   -   5        $��datagrid��55      $��1��6#   $��93,92,125,85q�63   
�������6\   �� 56   
   $��
VEHICLE NO��6   $��30��6%   $	��100��61   $��-250 -450 0 0q�6=   $��1��6T   �� 57   
   -   5        $��vhlno��57      $��30��6    $	��150��6,   $��-10 -450 0 0q�68    �� 
IsEditable . $��1��6�   58      59      