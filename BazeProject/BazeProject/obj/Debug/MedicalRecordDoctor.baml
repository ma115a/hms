   M S B A M L   `   `   `  ����F  BBazeProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BazeProjectBazeProject  5      %    BazeProject.MedicalRecordDoctor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BazeProject     5      $	��809��5   #   .��5	      � ���	#FFFDFDFC  � RowDefinitions  5
   
   �� 5      $��4* �6   �� 5      $��5* �6   �� 5      $��2* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��5* �6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��MedicalRecordGrid��5   0   $��0��6   $��2��6   $
��Auto��6I      AutoGenerateColumns .     
IsReadOnly . $��0q�5   9   $��14(�5         CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�5         Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Doctor Name��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6V   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *doctor_name+
   ElementStyle
 5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��TextAlignment �� Value$ Center=�6:   �� 5       � ��$ Center=�6>   5!      5#        5&      $
 Date��6!   $	 150 6H   	 6/   �� *date+
 5'      �� 5(      " ��6   .�5)      ��  �@��TextAlignment$ Center=�6:   �� 5*       � ��$ Center=�6>   5+      5-        50      $ 	Diagnosis��6!   $	 250 6R   	 64   �� *	diagnosis+
 51      �� 52      " ��6   .�53      ��  �@��TextAlignment$ Center=�6:   �� 54       � ��$ Center=�6>   �� 55       � ��$
 Wrap=�69   57      59        5<      $ 	Treatment��6!   $	 250 6R   	 64   �� *	treatment+
 5=      �� 5>      " ��6   .�5?      ��  �@��TextAlignment$ Center=�6:   �� 5@       � ��$ Center=�6>   �� 5A       � ��$
 Wrap=�69   5B      5D      5F      �� 5G   
   $��	Diagnosis��6   $��1��6$   $��Center=�61   $��14(�6N   $��	0,10,0,72q�6\   $��2��6o   �� 5H   
   -   5        $��DiagnosisBox��5H      $��1��6&   $��0��63   $	��120��6C   $	��300��6P   $��14(�6\   �� 5I   
   $��	Treatment��6   $��1��6$   $��1��61   $��Center=�6A   $��14(�6^   $��	0,10,0,72q�6l   $��2��6   �� 5J   
   -   5        $��TreatmentBox��5J      $��1��6&   $��1��63   $	��120��6C   $	��300��6P   $��14(�6\   �� 5K   
   -   5        $��Add Medical Record��5K      $��2��6.   $��2��6;   $��35��6O   $	��200��6[   $��14(�6g   $
��Bold"�6u   ���	#FF8CA06A � Cursor$
 Hand��6�   �� 5L   
   -   5        $��StatusLabel��5L      $��3��6$   $��2��61   $��Center=�6E   ���	#FFDE2A2A$��14(�6y   $
��Bold"�6�   5M      5O      