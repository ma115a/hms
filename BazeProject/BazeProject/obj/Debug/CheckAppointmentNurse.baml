   M S B A M L   `   `   `  ����F  BBazeProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BazeProjectBazeProject  5      '    !BazeProject.CheckAppointmentNurse   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BazeProject     5      .��5	      � ���	#FFFDFDFC  � RowDefinitions  5
   
   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��4* �6   �� 5      $��3* �6   .+�5   
   �� $��1��6   $��Select patient:��6!   $��Center=�68   $��Right=�6S   $��14(�6o   �� 5   
   -   5        $��PatientCombo��5      $��1��6'   $��1��64    �� Text$  ��6D   $	��300��6L   $��25��6X    �� 
IsEditable . $��Center=�6v   $��Center=�6�   5      �� 5   
   $��Select a date:��6   $��2��6*   $��Right=�67   $��Center=�6S   $��14(�6n   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DatePicker��5      $��2��6)   $��1��66   $	��300��6F   $��25��6R   $��14(�6^      SelectedDateFormat$ Short=�6l    � Cursor$
 Hand��6�      IsTodayHighlighted . 6�   �� 5   
   -   5        $��Check for Appointment��5      $��3��61   $��1��6>   $��25��6N   $	��189��6Z   $
 Hand��6f   ���	#FF8CA06A$��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $��StatusLabel��5      $�� ��6#   $��4��6.   $��1��6;   $��Center=�6K   $��Center=�6h   ���	#FFBE2F2F$��14(�6�   $
��Bold"�6�   5      5       