   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WinForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms  5      L HProject_Transport, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Project_TransportProject_Transport 5      #   Project_Transport.Expiry_view   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        5      R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	   5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	   5      @d2http://schemas.microsoft.com/expression/blend/2008  	   5      brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms  	   5      1localclr-namespace:Project_Transport  	   5      .��5
      � $	��550��6   $��	0,100,0,0q�6   
�������  � ColumnDefinitions  5   
   �� 5      $	��400 �6   �� 5      $	��850 �6   .+�5   
   �� -   5        $��label1��5      $��VEHICLE NUMBER��6   $��25��67   $	��150��6C   $��-200,-450,0,0q�6O   $��0��6f   �� 5   
   -   5        $
��text��5      $��25��6   $	��150��6+   $��100,-450,0,0q�67   $��0��6M    �� 
IsEditable . 6o   �� 5   
   -   5        $��label2��5      $
��YEAR��6   $��25��6-   $��50��69   $��-200,-330,0,0q�6D   $��0��6[   �� 5   
   -   5        $��combo��5      $��25��6    $	��120��6,   $��80,-330,0,0q�68   $��0��6M   .@�5      ��  �� 
IsSelected . .��6-   SELECT65   5      �� 5   
   -   5        $��label3��5      $��MONTH��6   $��25��6.   $��60��6:   $��-200,-210,0,0q�6E   $��0��6\   �� 5   
   -   5        $��combo1��5      $��25��6!   $	��120��6-   $��80,-210,0,0q�69   $��0��6N   .@�5      ��  . .��6-   SELECT65   �� 5      .��6   01-JAN6#   �� 5      .��6   02-FEB6#   �� 5      .��6   03-MAR6#   �� 5      .��6   04-APR6#   �� 5      .��6   05-MAY6#   �� 5      .��6   06-JUN6#   �� 5      .��6   07-JUL6#   �� 5      .��6   08-AUG6#   �� 5       .��6   09-SEP6#   �� 5!      .��6   10-OCT6#   �� 5"      .��6   11-NOV6#   �� 5#      .��6   12-DEC6#   5%      �� 5&   
   -   5        $��Tyre_Report��5&      $��REPORT��6$   $��30��65   $	��100��6A   $��
90,-50,0,0q�6M   $��0��6{   7  1System.Windows.Forms.Integration.WindowsFormsHost  5'   
   -   5        $
��host��5'      $	��470��6'   $	��700��64   $��1��6A   $��0,0,0,0q�6Q      
Background
 �����$y�Hidden=�6u      Child. 5(      /   )Microsoft.Reporting.WinForms.ReportViewer  -	   5        ReportViewer��5(      5)      5,      5-      