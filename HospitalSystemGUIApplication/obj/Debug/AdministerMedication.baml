   M S B A M L   `   `   `  ����W  SHospitalSystemGUIApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:HospitalSystemGUIApplicationHospitalSystemGUIApplication  5   	   7    1HospitalSystemGUIApplication.AdministerMedication   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:HospitalSystemGUIApplication     5   	     � Title$  Administer Medication��5   	   $��389.69��6'   $��212.277��67    � WindowStartupLocation$ CenterScreen=�6G   ���	#FFFDFFD2 � WindowStyle$
 None=�6�   .��5	      � ���	#FFBFB1B1.+�5
   
   �� -   5         ��Name$ txtblkAdminDrugTitle��5
      $
��Left=�62   $��	10,10,0,0q�6M   $
��Wrap=�6`   $��Administer Medication��6t   $	��Top=�6�   $��25��6�   $	��186��6�   $��Arial)�6�   $
��Bold"�6�   $��	Underline{�6�   $��16(�6   �� TextAlignment$ Center=�6  �� 5   
   -   5         ��Name$ 
cmbPatient��5      $
��Left=�6'   $��	10,72,0,0q�6B   $	��Top=�6U   $	��174��6m   6y   �� 5   
   -   5        $ cmbDrug��5      $
��Left=�6$   $��
10,128,0,0q�6?   $	��Top=�6S   $	��174��6k   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpkrAdministerDate��5      $
��Left=�61   $��
10,180,0,0q�6L   $	��Top=�6`   $	��174��6x   �� 5   
   -   5         ��Name$ txtTime��5      $
��Left=�6#   $��23��6>   $��
10,237,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��174��6�   �� 5   
   -   5        $ cmbNurse��5      $
��Left=�6%   $��
10,296,0,0q�6@   $	��Top=�6T   $	��174��6l   �� 5   
   -   5        	 ��Name$	 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
10,336,0,0q�6P   $	��Top=�6d   $��68��6|   $��30��6�   ���	#FFED86866�   �� 5   
   -   5        $	 btnAdministerMedication��5      $��
Administer��62   $
��Left=�6G   $��113,336,0,0q�6b   $	��Top=�6w   $��71��6�   $��30��6�   ���	#FF58D9966�   �� 5   
   -	   5        
 ��Name$
 
lblPatient��5      $��Patient:��6$   $
��Left=�67   $��	10,42,0,0q�6R   $	��Top=�6e   $	��174��6}   $��30��6�   $��Arial Black)�6�   �� 5   
   -
   5        $
 lblDrug��5      $��Drug:��6!   $
��Left=�61   $��	10,96,0,0q�6L   $	��Top=�6_   $	��174��6w   $��32��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblDate��5      $��Administer Date:��6!   $
��Left=�6<   $��
10,152,0,0q�6W   $	��Top=�6k   $	��174��6�   $��28��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblTime��5      $��Administer Time:��6!   $
��Left=�6<   $��
10,209,0,0q�6W   $	��Top=�6k   $	��174��6�   $��23��6�   $��Arial Black)�6�   �� 5   
   -   5        $
 lblNurse��5      $��Nurse:��6"   $
��Left=�63   $��
10,269,0,0q�6N   $	��Top=�6b   $	��174��6z   $��22��6�   $��Arial Black)�6�   5      5      