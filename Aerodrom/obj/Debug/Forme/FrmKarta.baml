   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aerodrom.FormeAerodrom.Forme  5   	       Aerodrom.Forme.FrmKarta   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Aerodrom.Forme     5   	     � Title$  Dodaj/Izmeni kartu��5   	   $	��350��6$   $	��300��61   .��5	      � .+�5
   
   �� $��Broj karte:��6   $
��Left=�6&   $��	36,43,0,0q�6A   $	��Top=�6T   �� 5   
   $��
Broj leta:��6   $
��Left=�6%   $��	43,77,0,0q�6@   $	��Top=�6S   �� 5   
   $
��Let:��6   $
��Left=�6   $��
71,114,0,0q�6:   $	��Top=�6N   �� 5   
   $��Rezervacija:��6   $
��Left=�6'   $��
29,156,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$ txtBrojKarte��5      $
��Left=�6(   $��
112,47,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ txtBrojLeta��5      $
��Left=�6'   $��
112,81,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   -   5         ��Name$ 
cbLetKarta��5      $
��Left=�6'   $��112,116,0,0q�6B   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ letNaziv��6{    �� SelectedValuePath$ letID��6�   �� 5   
   -   5        $ cbRezervacija��5      $
��Left=�6*   $��112,160,0,0q�6E   $	��Top=�6Z   $	��120��6r   $ brojRezervacije��6~   $ rezervacijaID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
64,245,0,0q�6R   $	��Top=�6f   $��76��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��172,245,0,0q�6P   $	��Top=�6e   $��75��6}    J� RenderTransformOrigin$ 0.493,0.553&�6�   6�   5      5      