   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AerodromAerodrom  5   	       Aerodrom.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Aerodrom     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��700��6)   .��5	      � ��5
   
   �� 5       �� ImageSource$1 +C:\Users\Nikola\Desktop\Projekat\slidza.png��6    �� Opacity$	 0.9Q�6T   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      
�������$��Center=�6?   $��Center=�6\   $
��auto��6w   $
��auto��6�      
IsReadOnly .    AlternatingRowBackground
 ��ح�   CanUserAddRows .     SelectionUnit$ FullRow=�5   H      SelectionMode$ Single=�6`   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $	��650��6W    �� Orientation$ 
Horizontal=�6c   $��2��6|   $��50,0,0,0q�6�   .+�5      �� -   5        	 ��Name$	 btnLet��5      $	��Let��6%   $��30��63   $	��Top=�6?   $��61��6W   6b   �� 5      -   5        $	 btnAvion��5      $��Avion��6'   $��30��67   $	��Top=�6C   $��61��6[   6f   �� 5      -   5        $	 btnAvioKompanija��5      $��AvioKompanija��6/   $��30��6G   $	��Top=�6S   $��97��6k   6v   �� 5      -   5        $	 btnAerodrom��5      $��Aerodrom��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��75��6|   6�   �� 5      -   5        $	 
btnPutnici��5      $��Putnici��6)   $
��Left=�6;   $��30��6V   $	��Top=�6b   $��75��6z   6�   �� 5      -   5        $	 btnKarta��5      $��Karta��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $	 btnRezervacijaLeta��5      $��Rezervacija��61   $
��Left=�6H   $	��Top=�6c   $��30��6{   $��75��6�   6�   �� 5      -	   5        $	 btnPilot��5      $��Pilot��6'   $��30��67   $	��Top=�6C   $��75��6[   6f   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   $��0,0,0,0q�6   .+�5      �� -
   5        $	 btnDodaj��5      $��Dodaj��6'   $	��120��67   6C   �� 5      -   5        $	 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   6E   �� 5      -   5        $	 	btnObrisi��5      $��Obriši��6(   $	��120��69   6E   5      5"      5#      