   M S B A M L   `   `   `  ����W  SHospitalSystemGUIApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HospitalSystemGUIApplicationHospitalSystemGUIApplication  5   	   0    *HospitalSystemGUIApplication.PrescribeDrug   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:HospitalSystemGUIApplication     5   	     � Title$  Prescribe Drug��5   	   $��534.896��6    $��288.893��61    � WindowStartupLocation$ CenterScreen=�6A   ���	#FFBFB1B1 � WindowStyle$
 None=�6}   .��5	      � .+�5
   
   �� -   5         ��Name$ txtblkPrescribeDrugTitle��5
      $
��Left=�66   $��	10,10,0,0q�6Q   $
��Wrap=�6d   $��Prescribe Drug��6x   $	��Top=�6�   $��40��6�   $	��249��6�   $��Arial)�6�   $��24(�6�   $��	Underline{�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6  �� 5   
   -   5         ��Name$ txtDrugName��5      $
��Left=�6'   $��23��6B   $��
26,146,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $��	Drug Name��6v   $	��Top=�6�   $	��233��6�    �� TextAlignment$ Center=�6�   6�   �� 5   
   -   5        $ 	txtDosage��5      $
��Left=�6%   $��23��6@   $��
26,205,0,0q�6L   $
 Wrap=�6`   $��Dosage��6t   $	��Top=�6�   $	��233��6�   $ Center=�6�   6�   �� 5   
   -   5        $ txtInstructions��5      $
��Left=�6+   $��71��6F   $��
26,253,0,0q�6R   $
 Wrap=�6f   $��Instructions��6z   $	��Top=�6�   $	��233��6�   $ Center=�6�   " �� VerticalScrollBarVisibility$ Visible=�6  (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dpkrPrescribeDate��5      $
��Left=�60   $��109,343,0,0q�6K   $	��Top=�6`   $	��150��6x   �� 5   
   -   5        
 ��Name$
 
cmbPatient��5      $
��Left=�6'   $��
109,91,0,0q�6B   $	��Top=�6V   $	��150��6n   �� 5   
   -   5        $
 	cmbDoctor��5      $
��Left=�6&   $	��Top=�6A   $	��150��6Y   $��109,390,0,0q�6e   �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
10,460,0,0q�6P   $	��Top=�6d   $	��107��6|   $��45��6�   ���	#FFED86866�   �� 5   
   -	   5        $ btnPrescribeDrug��5      $��Prescribe Drug��6+   $
��Left=�6D   $��143,460,0,0q�6_   $	��Top=�6t   $	��116��6�   $��45��6�   ���	#FF58D9966�   �� 5   
   -
   5         ��Name$ 
lblPatient��5      $��Patient:��6$   $
��Left=�67   $��	26,91,0,0q�6R   $	��Top=�6e   $��78��6}   $��34��6�   $��Arial Black)�6�   �� 5   
   -   5        $ lblDate��5      $��Date:��6!   $
��Left=�61   $��
26,343,0,0q�6L   $	��Top=�6`   $��78��6x   $��37��6�   $��Arial Black)�6�   �� 5   
   -   5        $ 	lblDoctor��5      $��Doctor:��6#   $
��Left=�65   $��
26,390,0,0q�6P   $	��Top=�6d   $��78��6|   $��39��6�   $��Arial Black)�6�   5      5      