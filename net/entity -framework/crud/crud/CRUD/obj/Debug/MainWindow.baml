   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5   	       CRUD.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:CRUD     5   	   -   5          �Name$  WndMain��5   	    � Title$, &CRUD [ Entity Framework + SQL Server ]��5   	   $	��411��68   $	��869��6E   $��530.015��6Q   $��421.267��6d   .��5	      � $��	0,0,15,25q�6    � ColumnDefinitions 5
   
   �� 5      $
��244* �6   �� 5      $	��54* �6   �� 5      $
��129* �6   .+�5   
   �� -   5         ��Name$ CmdSale��5      $
��Sale��6"   $
��Left=�61   $��34��6L   $��0,21,0,0q�6X   $	��Top=�6j   $	��137��6�   $��2��6�   $��1��6�   �� 5   
   -   5        $ CmdFind��5      $
��Find��6"   $
��Left=�61   $��34��6L   $��	31,21,0,0q�6X   $	��Top=�6k   $	��137��6�   �� 5   
   -   5        $ CmdFindProduct��5      $��Find Product��6)   $
��Left=�6@   $��34��6[   $��
334,21,0,0q�6g   $	��Top=�6{   $	��137��6�   �� 5   
   -   5        $ CmdSalePlusRemove��5      $��Sale and Remove��6,   $
��Left=�6F   $��34��6a   $��	49,21,0,0q�6m   $	��Top=�6�   $	��138��6�   $��2��6�   �� 5   
   -   5        $ 	CmdFindV2��5      $��Find -Version II��6$   $
��Left=�6?   $��34��6Z   $��
182,21,0,0q�6f   $	��Top=�6z   $	��137��6�   �� 5   
   -   5         ��Name$ 
ListClient��5      $��31,117,302,0q�6Q    �� SelectionMode$ Multiple=�6g   $
��10.5(�6�   �� 5   
   -   5        $ ListProduct��5      $��207,117,126,0q�6R    � 
InputScope$ Default��6i   $ Multiple=�6~   $
��10.5(�6�   �� 5   
   -	   5        $ 
ListResult��5      $��390,117,10,0q�6Q   $ Default��6g   $ Multiple=�6|   $
��10.5(�6�   $��3��6�   �� 5   
   -
   5         ��Name$ 	LblClient��5      $��Clients��6#   $
��Left=�65   $��	31,86,0,0q�6P   $	��Top=�6c    J� RenderTransformOrigin$ -7.195,0.492&�6{   $	��155��6�   $��11(�6�   $
��Bold"�6�   �� 5   
   -   5        $ 
LblProduct��5      $��Products��6$   $
��Left=�67   $��
207,86,0,0q�6R   $	��Top=�6f   $ -7.195,0.492&�6~   $	��155��6�   $��11(�6�   $
��Bold"�6�   �� 5   
   -   5        $ LblItems��5      $��Items��6"   $
��Left=�62   $��
390,86,0,0q�6M   $	��Top=�6a   $ -7.195,0.492&�6y   $	��454��6�   $��11(�6�   $
��Bold"�6�   $��3��6�   5      5      