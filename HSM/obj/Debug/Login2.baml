   M S B A M L   `   `   `  ����>  :HSM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HSM.ControlHSM.Control  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       
HSM.Login2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HSM.Control     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesgin1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � WindowStartupLocation$  CenterScreen=�5
       � WindowStyle$
 None=�6?    � AllowsTransparency .  � Title$ 
MainWindow��5   	   $	��370��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   �� -   5        $��D:\google_dw\reject.png��5      $��1��61    K� ZIndex$ 1��6A      
imageclose#��[  6j   �� 5   
    �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      � 	 � Color$	 #3AA9AD��6#   
 � Offset$
 0Q�63   � 5      $	 #3AA9AD��6#   $
 1Q�63   5      ._�5      � .+�5      �� 5"      5#      �� 5$   
   .+�5%      �  � Points �    -1��� ;X�����#4EB1B6
 �� Top$ 22��6A   $��Center=�6Q   $	��Top=�6n    J� RenderTransformOrigin$ 0.514,1.098&�6�   $	��306��6�   $	��368��6�   � 5&      ' �    �� �� ���� ��
�����#4EB1B6$
��Left=�6F   $
 -110��6a   $	��Top=�6s    �� Left$ 91��6�   A� 5'      $��40��6   $��40��6!   ���#4EB1B6$	 132��6<   $	 308��6N   A� 5(      $��20��6   $��20��6!   ���#4EB1B6$ 
1.81,4.848&�6<   $ 45��6_   $	 286��6p   $
��Left=�6�   $	��Top=�6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-       �� Angle$ 15.881Q�6*   T� 5.       T� X$ -24.795Q�6-    T� Y$ 3.847Q�69   5/      51      52      �� 54   
   -   5        ���#ffffff$��1��54   &   $ 	0 10 10 0��66   ._�55      �� .+�56      �� $��Patient Login��6     	titleText#��[ 61   ���#3AA9AD$	��131��6u   �� 58      $��1q�6   ���#abc0af$
��70 7q�6C   $ 5��6Q   ._�59      � $	��7 9q�6    5:      �� 5;      $
��auto �6/   �� 5<      $��* �6/   .+�5?      �� $,��&D:\google_dw\5856-removebg-preview.png��6    $��25��6P   �� 5@      -   5         ��Name$ PatientName��5@   $   $��Patient Name��6[     textHint#��[ 6p   �� 5A      -   5         ��Name$ PatientName1��5A   "     textbox#��[ 6_   5C      5E      �� 5F      $��1q�6   ���#abc0af$
��70 7q�6C   $ 5��6Q   ._�5G      � $	��7 9q�6    5H      �� 5J      $
��auto �6/   �� 5K      $��* �6/   .+�5N      �� $W��QD:\google_dw\depositphotos_660012834-stock-illustration-flat-design-icon-card.jpg��6    $��25��6{   �� 5P      -   5        $ 	PatientID��5P   $   $��
Patient ID��6W   #��[ 6i   �� 5Q      -   5        $ 
PatientID1��5Q   "   #��[ 6[   5S      5U      �� 5V      -   5         ��Name$ Login��5V      $��Submit��6(     
mainbutton#��[ 6:   $��0 50 0 0q�6^   6p   5W      5X      �� 5Y   
   $��Center=�6   $	��232��6-   $��Center=�6:   $	��274��6U   $A��;/_00321075-e172-4551-b0c3-11b7b1235345-removebg-preview.png��6a   $ 0.672,0.487&�6�   (  "System.Windows.Controls.DatePicker  5Z   
   -   5        $��
datePicker��5Z   0   $
��Left=�6   $ 0.624,1.778&�6B   $��
54,253,0,0q�6f   $��28��6z   $	��Top=�6�   $��21��6�   $��1��6�   �� 5[   
   -	   5        $
 date��5[      $��Select Date��6   $
��Left=�65   $	��Top=�6P   $��
80,251,0,0q�6h   $��1��6�   5]      5`      