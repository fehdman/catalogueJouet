   M S B A M L   `   `   `  ����  CatalogueDeJouet    CatalogueDeJouet.WAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Panneau Responsable CE��5   	   $	��361��6(   $	��802��65   .��5      � .+�5   
   �� -   5         ��Name$ lblTitre��5      $4��.Récapitulatif des jouets choisis par employé��6"   $
��Left=�6Y   $��26��6t   $��10,6,0,0q�6�   $	��Top=�6�   $	��259��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtAffichage��5         AutoGenerateColumns .  $
��Left=�6F   $	��241��6a   $��	31,49,0,0q�6n   $	��Top=�6�   $	��720��6�      Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6K      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6&   �� *Nom+5      4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Enfants��6)   $	 200 6;   	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 
lstEnfants��6'   $��0,0,0,0q�6_   $	��200��6q   ��6;   �� *
LesEnfants+6q   5      5      5      �� 5   
   -   5         ��Name$ btnNbJouets��5      $��	nb Jouets��6'   $
��Left=�6;   $��22��6V   $��
315,10,0,0q�6b   $	��Top=�6v   $��86��6�   6�   �� 5   
   -   5        $ btnNbJouetCateg��5      $��Jouets par catégorie��6+   $
��Left=�6J   $��22��6e   $��
435,10,0,0q�6q   $	��Top=�6�   $	��147��6�   6�   �� 5   
   -   5        $ btnDeconnecter��5      $��se déconnecter��6*   $
��Left=�6C   $��26��6^   $��512,295,0,0q�6j   $	��Top=�6   $	��110��6�   6�   5      5      