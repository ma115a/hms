   M S B A M L   `   `   `  ����F  BBazeProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BazeProjectBazeProject  5      )    #BazeProject.LaboratoryResultsDoctor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BazeProject     5      .��5	      � ���	#FFFDFDFC  � ColumnDefinitions  5
   
   �� 5      $
��0.5* �6   �� 5      $
��7.5* �6   �� 5      $
��0.5* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��LabResultGrid��5   D   $��0��6   $��1��6    $��1��64   $
��Auto��6Y      AutoGenerateColumns .     
IsReadOnly . $��0q�5   5   $��14(�5         CanUserAddRows .  $   HorizontalScrollBarVisibility$
 Auto=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Doctor Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
doc_name+	   ElementStyle	 5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property �@��TextAlignment �� Value$ Center=�6>   �� 5       � ��$ Center=�6B   5      5        5!      $ Tehnician Name��6%   $	 150 6[    6=   �� *	tech_name+	 5"      �� 5#      "
 ��6    .�5$      ��  �@��TextAlignment$ Center=�6>   �� 5%       � ��$ Center=�6B   5&      5(        5+      $
 Date��6%   $	 250 6L    63   �� *date+	 5,      �� 5-      "
 ��6    .�5.      ��  �@��TextAlignment$ Center=�6>   �� 5/       � ��$ Center=�6B   �� 50       � ��$
 Wrap=�6=   52      54        57      $ Result��6%   $	 250 6P    65   �� *result+	 58      �� 59      "
 ��6    .�5:      ��  �@��TextAlignment$ Center=�6>   �� 5;       � ��$ Center=�6B   �� 5<       � ��$
 Wrap=�6=   5=      5?      5A      5B      5C      