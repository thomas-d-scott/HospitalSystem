   M S B A M L   `   `   `  ����W  SHospitalSystemGUIApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HospitalSystemGUIApplicationHospitalSystemGUIApplication  5   	   4    .HospitalSystemGUIApplication.RecordMeasurement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:HospitalSystemGUIApplication     5   	     � Title$  Record Measurement��5   	   $��510.553��6$   $��376.102��65    � WindowStartupLocation$ CenterScreen=�6E   ���	#FFFDFFD2 � WindowStyle$
 None=�6�   .��5	      � ���	#FFBFB1B1.+�5
   
   �� -   5         ��Name$" txtblkRecordMeasurementTitle��5
      $
��Left=�6:   $��	10,10,0,0q�6U   $
��Wrap=�6h   $��Record Measurement��6|   $	��Top=�6�   $��46��6�   $	��330��6�   $��Arial)�6�   $
��Bold"�6�   $��	Underline{�6�   $��24(�6   �� TextAlignment$ Center=�6  �� 5   
   -   5         ��Name$ 
cmbPatient��5      $
��Left=�6'   $��
190,78,0,0q�6B   $	��Top=�6V   $	��150��6n   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpkrMeasurementDate��5      $
��Left=�62   $��190,129,0,0q�6M   $	��Top=�6b   $	��150��6z   �� 5   
   -   5         ��Name$ txtTime��5      $
��Left=�6#   $��23��6>   $��190,179,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��150��6�   �� 5   
   -   5        $ txtBloodPressureSystolic��5      $
��Left=�64   $��23��6O   $��190,229,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��150��6�   �� 5   
   -   5        $ txtTemperature��5      $
��Left=�6*   $��23��6E   $��190,330,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��150��6�   �� 5   
   -   5        $ cmbNurse��5      $
��Left=�6%   $��190,382,0,0q�6@   $	��Top=�6U   $	��150��6m   �� 5   
   -   5        	 ��Name$	 btnRecordMeasurement��5      $��Record Measurement��6/   $
��Left=�6L   $��190,439,0,0q�6g   $	��Top=�6|   $	��150��6�   $��40��6�   ���	#FF58D9966�   �� 5   
   -	   5        $	 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
10,439,0,0q�6P   $	��Top=�6d   $	��145��6|   $��40��6�   ���	#FFCD501F6�   �� 5   
   -
   5        
 ��Name$
 
lblPatient��5      $��Patient:��6$   $
��Left=�67   $��	10,77,0,0q�6R   $	��Top=�6e   $	��175��6}   $��39��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblDate��5      $��Measurement Date:��6!   $
��Left=�6=   $��
10,128,0,0q�6X   $	��Top=�6l   $	��175��6�   $��37��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblTime��5      $��Measurement Time:��6!   $
��Left=�6=   $��
10,178,0,0q�6X   $	��Top=�6l   $	��175��6�   $��35��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblSysBP��5      $��Systolic Blood Pressure:��6"   $
��Left=�6E   $��
10,228,0,0q�6`   $	��Top=�6t   $	��175��6�   $��24��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblTemp��5      $��Temperature��6!   $
��Left=�67   $��
10,329,0,0q�6R   $	��Top=�6f   $	��175��6~   $��38��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblNurse��5      $��Nurse��6"   $
��Left=�62   $��
10,381,0,0q�6M   $	��Top=�6a   $	��175��6y   $��39��6�   $��Arial Black)�6�   �� 5   
   -   5        $ txtBloodPressureDiastolic��5      $
��Left=�65   $��23��6P   $��190,268,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $	��150��6�   �� 5   
   -   5        $
 lblDiaBP��5      $��Diastolic Blood Pressure:��6"   $
��Left=�6F   $��
10,268,0,0q�6a   $	��Top=�6u   $	��175��6�   $��24��6�   $��Arial Black)�6�   5      5      