   M S B A M L   `   `   `  ����W  SHospitalSystemGUIApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HospitalSystemGUIApplicationHospitalSystemGUIApplication  5   	   -    'HospitalSystemGUIApplication.AddPatient   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:HospitalSystemGUIApplication     5   	     � Title$  Add Patient��5   	   $��366.008��6   $��289.851��6.    � WindowStartupLocation$ CenterScreen=�6>   ���	#FFBFB1B1 � WindowStyle$
 None=�6z   .��5	      � .+�5
   
   �� -   5         ��Name$ txtblkAddPatientTitle��5
      $
��Left=�63   $��	10,10,0,0q�6N   $
��Wrap=�6a   $��Add Patient��6u   $	��Top=�6�   $��41��6�   $	��248��6�   $��Arial)�6�   $��36(�6�   $��	Underline{�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6  �� 5   
   -   5         ��Name$ txtPatientName��5      $
��Left=�6*   $��23��6E   $��	24,88,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��235��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��	Full Name��6�    �� TextAlignment$ Center=�6�   .��6,  z�5      V� 5      .~�5      �� �� 5      �� 5      	 �� Angle$	 -0.078Q�6&   T� 5      5      .��5   '   5      �� 5   
   -   5        $ txtPatientAddress��5      $
��Left=�6-   $��23��6H   $��
23,129,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��235��6�   $��Address��6�   $ Center=�6�   6�   �� 5   
   -   5        $ txtPatientTown��5      $
��Left=�6*   $��23��6E   $��
23,173,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��235��6�   $
��Town��6�   $ Center=�6�   6�   �� 5   
   -   5        $ txtPatientPostcode��5      $
��Left=�6.   $��23��6I   $��
23,217,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��235��6�   $��Postcode��6�   $ Center=�6�   6�   �� 5   
   -   5        
 ��Name$
 cmbConsultants��5      $
��Left=�6+   $��118,259,0,0q�6F   $	��Top=�6[   $	��140��6s   �� 5   
   -   5         ��Name$ btnAddPatient��5      $��Add Patient��6(   $
��Left=�6>   $��161,311,0,0q�6Y   $	��Top=�6n   $��97��6�   $��31��6�   ���	#FF58D9966�   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
23,311,0,0q�6P   $	��Top=�6d   $	��102��6|   $��31��6�   ���	#FFCD501F6�   �� 5   
   -	   5         ��Name$ lblConsultant��5      $��Consultant:��6'   $
��Left=�6=   $��
23,259,0,0q�6X   $	��Top=�6l   $��35��6�   $��90��6�   $��Arial Black)�6�   5      5      