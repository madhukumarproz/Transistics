   M S B A M L   `   `   `  ����L  HProject_Transport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TransportProject_Transport  5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization 5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	   !    Project_Transport.Dashboard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5   	   @d2http://schemas.microsoft.com/expression/blend/2008  	   5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5   	   1localclr-namespace:Project_Transport  	   5   	   �datavisrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit  	   5   	   �chart{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit  	   5   	   -   5        $	��550��5   
   $
��1250��6     � 	Resources  5         
blinkLabel g� Duration g� RepeatBehavior �� 
TargetName �� TargetProperty �� KeyTime �� Value��%N  &	        �� 5   
   $ 0:0:1D�6(   $ Forever��5      .��5      �� $	 lbl��5      $( "Background.(SolidColorBrush.Color)�5      .g�5      p� $ 0:0:0��6(   $	 Red��68   p� 5      $ 0:0:0.5��6(   $ White��6:   5      �� 5      $	 lbl��5      $( "Foreground.(SolidColorBrush.Color)�5      .g�5      p� $ 0:0:0��6(   $ White��68   p� 5      $ 0:0:0.5��6(   $ Black��6:   5      �� 5      $
 lbl1��5      $( "Background.(SolidColorBrush.Color)�5      .g�5      p� $ 0:0:0��6(   $	 Red��68   p� 5      $ 0:0:0.5��6(   $ White��6:   5       �� 5!      $
 lbl1��5"      $( "Foreground.(SolidColorBrush.Color)�5#      .g�5$      p� $ 0:0:0��6(   $ White��68   p� 5%      $ 0:0:0.5��6(   $ Black��6:   5&      5'      5(       � Triggers 5)      :� 5*   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5+      �� #��[  6   5,      .��5.      � $	��550��6   $��0 00 0 0q�6   
�������.+�5/   
   �� -   5        $	��lbl��5/      $��30��6   $	��130��6'   $��-750 -500 0 0q�63   $��15(�6J   $
��Bold"�6X   $��calibri)�6j   .��6   Document Expiry6�   �� 50   
   -   5        $
��lbl1��50      $��30��6   $	��120��6(   $��80 -500 0 0q�64   $��15(�6I   $
��Bold"�6W   $��calibri)�6i   .��6~   License Expiry6�   �� 51   
   $��30��6   $	��120��6   $��800 -500 0 0q�6(   $��15(�6>   $
��Bold"�6L   $��calibri)�6^   .��6s   
Short Note6   ,� 52   
   $��	10,40,0,0q�6#   $	��450��66   $	��200��6B   $	��Top=�6O   $
��Left=�6g   .��53      /� -   5        	 �Name$	 	tableView��53      6/   54      ,� 55   
   $��
500,40,0,0q�6#   $	��350��67   $	��200��6C   $	��Top=�6P   $
��Left=�6h   .��56      /� -   5        $	 
tableView1��56      5:      5;      �� 5=   
   -   5        $��sticky��5=      $	��200��6#   $	��300��60   $��800 -270 0 0q�6<   $y�Visible=�6R   .+�5>      �� -   5        $��rtbox��5>      $	��200��6'   $	��300��64   6x   5?      >  8System.Windows.Controls.DataVisualization.Charting.Chart  5@   
   -   5        $��columnChart��5@   Q   $	��262��6   $
��Left=�6#   $��	50,0,0,40q�6>   
   Title$
 Trip Status��6d   $��Bottom=�6x   $	��360��6�   $��0q�6�      LegendStyle 5A      �� 5B       �� 
TargetType6  0System.Windows.Controls.DataVisualization.Legend"  6   .�5C      ��  �� Property � �� �� Value$ 0��6.   5D         Series. 5F      E  ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  $	��170��6!   $	��330��6.   $��0 0 0 0q�6:   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value��6K      IndependentValuePath$	 Key��6f      ItemsSource 6�   �� 5G        5H   
   -	   5        $��	areaChart��5H   R   $	��262��6   $
��Left=�6#   $��
450,0,0,40q�6>   $
 Total Trips��6c   $��Bottom=�6w   $	��360��6�   $��0q�6�    5I      �� 5J      "  6   .�5K      ��  � ��$ 0��6.   5L      . 5N      C  =System.Windows.Controls.DataVisualization.Charting.AreaSeries  $ Value��6    $	 Key��6;    6V   �� 5O      �� 5P   
   $��30��6   $	��150��6   $��	HOT LINKS��6(   $��Center=�6<   $��
850 10 0 0q�6`   
�������6�   �� 5Q   
   $��
860 80 0 0q�6   $��30��6(   $	��120��64   $��16(�6@    5R      :� 5S      $ FrameworkElement.Loaded��6    .[�5U      �� .��5V      �� .��5W      W� $ (TextBlock.Opacity)�6.    W� From$ 1X�5Y      	 W� To$ 0X�6    g� AutoReverse .  g� 	BeginTime$ 0:0:0X�5Z      $ 0:0:1D�6#   $ Forever��64   5]      5^      5_      5`      �� 5a   #   -
   5        .�5a   K   Diesel Payment6[   6g   �� 5b   
   $��860 160 0 0q�6   $��30��6)   $	��120��65   $��16(�6A    5c      :� 5d      $ FrameworkElement.Loaded��6    .[�5f      �� .��5g      �� .��5h      W� $ (TextBlock.Opacity)�6.   $ 1X�5j      $ 0X�6    . $ 0:0:0X�5k      $ 0:0:1D�6#   $ Forever��64   5n      5o      5p      5q      �� 5s      -   5        .�5s   4   Lpg Trip Entry6D   6P   �� 5t   
   $��860 230 0 0q�6   $��30��6)   $	��120��65   $��16(�6A    5u      :� 5v      $ FrameworkElement.Loaded��6    .[�5x      �� .��5y      �� .��5z      W� $ (TextBlock.Opacity)�6.   $ 1X�5|      $ 0X�6    . $ 0:0:0X�5}      $ 0:0:1D�6#   $ Forever��64   5�      5�      5�      5�      �� 5�   #   -   5        .�5�   I   Load-Trailer6W   6c   �� 5�   
   $��860 300 0 0q�6   $��30��6)   $	��120��65   $��16(�6A    5�      :� 5�      $ FrameworkElement.Loaded��6    .[�5�      �� .��5�      �� .��5�      W� $ (TextBlock.Opacity)�6.   $ 1X�5�      $ 0X�6    . $ 0:0:0X�5�      $ 0:0:1D�6#   $ Forever��64   5�      5�      5�      5�      �� 5�   #   -   5        .�5�   H   LPG Payment6U   6a   �� 5�   
   $��860 370 0 0q�6   $��30��6)   $	��120��65   $��16(�6A    5�      :� 5�      $ FrameworkElement.Loaded��6    .[�5�      �� .��5�      �� .��5�      W� $ (TextBlock.Opacity)�6.   $ 1X�5�      $ 0X�6    . $ 0:0:0X�5�      $ 0:0:1D�6#   $ Forever��64   5�      5�      5�      5�      �� 5�   #   -   5        .�5�   I   Load Payment6W   6c   �� 5�   
   $��860 440 0 0q�6   $��30��6)   $	��120��65   $��16(�6A    5�      :� 5�      $ FrameworkElement.Loaded��6    .[�5�      �� .��5�      �� .��5�      W� $ (TextBlock.Opacity)�6.   $ 1X�5�      $ 0X�6    . $ 0:0:0X�5�      $ 0:0:1D�6#   $ Forever��64   5�      5�      5�      5�      �� 5�   #   -   5        .�5�   C   Profit View6P   6\   �� 5�   
   $��30��6   $	��360��6   $��
30 520 0 0q�6(   $��14(�6<   .��5�      �� -   5        .�5�   2   53@Powered by ProZ Solutions Namakkal Call:81223990816g   5�      5�      5�      