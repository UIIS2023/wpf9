   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aerodrom.FormeAerodrom.Forme  5   	       Aerodrom.Forme.FrmLet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Aerodrom.Forme     5   	     � Title$  Dodaj/izmeni let��5   	   $	��350��6"   $	��300��6/   .��5	      � .+�5
   
   �� $��Naziv leta: ��6   $
��Left=�6'   $��32��6B   $��	27,10,0,0q�6N   $	��Top=�6a   $��73��6y   �� 5   
   -   5         ��Name$ txtNazivLeta��5      $
��Left=�6(   $��
108,17,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   �� 5   
   $��Kapacitet: ��6   $
��Left=�6&   $��	30,44,0,0q�6A   $	��Top=�6T   $��65��6l   �� 5   
   $��Vreme poletanja: ��6   $
��Left=�6,   $��8,75,0,0q�6G   $	��Top=�6Y   $	��108��6q   �� 5   
   $��Vreme sletanja: ��6   $
��Left=�6+   $��
14,102,0,0q�6F   $	��Top=�6Z   $��98��6r   �� 5   
   $��Destinacija: ��6   $
��Left=�6(   $��
35,133,0,0q�6C   $	��Top=�6W   $��73��6o   �� 5   
   $��Cena: ��6   $
��Left=�6!   $��
52,163,0,0q�6<   $	��Top=�6P   $��64��6h   �� 5   
   -   5        $ txtKapacitet��5      $
��Left=�6(   $��
108,48,0,0q�6C   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ txtVrPoletanja��5      $
��Left=�6*   $��
108,79,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $ txtVrSletanja��5      $
��Left=�6)   $��108,106,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��120��6�   �� 5   
   -   5        $ txtDestinacija��5      $
��Left=�6*   $��108,137,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��120��6�   �� 5   
   -   5        $ txtCena��5      $
��Left=�6#   $��108,167,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5   
   -   5         ��Name$ cbAvion��5      $
��Left=�6$   $��108,199,0,0q�6?   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$ model��6x    �� SelectedValuePath$ avionID��6�   �� 5   
   $��Avion: ��6   $
��Left=�6"   $��
50,197,0,0q�6=   $	��Top=�6Q    J� RenderTransformOrigin$ 0.407,0.926&�6i   �� 5   
   $��
Aerodrom: ��6   $
��Left=�6%   $��
37,230,0,0q�6@   $	��Top=�6T   �� 5   
   $��Pilot: ��6   $
��Left=�6"   $��
58,259,0,0q�6=   $	��Top=�6Q   $ 0.557,0.618&�6i   �� 5   
   -   5        $ 
cbAerodrom��5      $
��Left=�6'   $��108,230,0,0q�6B   $	��Top=�6W   $	��120��6o   $ nazivAerodroma��6{   $ 
aerodromID��6�   �� 5   
   -	   5        $ cbPilot��5      $
��Left=�6$   $��108,261,0,0q�6?   $	��Top=�6T   $	��120��6l   $ prezimePilota��6y   $ pilotID��6�   �� 5   
   -
   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
62,304,0,0q�6R   $	��Top=�6f   $��76��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��175,304,0,0q�6P   $	��Top=�6e   $��75��6}   $ 0.493,0.553&�6�   6�   5"      5#      