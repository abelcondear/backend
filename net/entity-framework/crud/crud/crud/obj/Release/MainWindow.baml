   M S B A M L   `   `   `  ���� ?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD      CRUD.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:CRUD     -     �Name$  WndMain�� � Title$, &CRUD [ Entity Framework + SQL Server ]��$	��411��$	��869��$��530.015��$��421.267��.��� $��	0,0,15,25q� � ColumnDefinitions �� $
��244* ��� $	��54* ��� $
��129* �.+��� -    ��Name$ CmdSale��$
��Sale��$
��Left=�$��34��$��
476,21,0,0q�$	��Top=�$	��137��$��3���� -   $ CmdFind��$
��Find��$
��Left=�$��34��$��	31,21,0,0q�$	��Top=�$	��137���� -   $ CmdFindProduct��$��Find Product��$
��Left=�$��34��$��
334,21,0,0q�$	��Top=�$	��137���� -   $ CmdSalePlusRemove��$��Sale and Remove��$
��Left=�$��34��$��	22,21,0,0q�$	��Top=�$	��138��$��2���� -   $ 	CmdFindV2��$��Find -Version II��$
��Left=�$��34��$��
182,21,0,0q�$	��Top=�$	��137���� -    ��Name$ 
ListClient��$��31,117,302,0q� �� SelectionMode$ Multiple=�$
��10.5(��� -   $ ListProduct��$��207,117,126,0q� � 
InputScope$ Default��$ Multiple=�$
��10.5(��� -	   $ 
ListResult��$��390,117,10,0q�$ Default��$ Multiple=�$
��10.5(�$��3���� -
    ��Name$ 	LblClient��$��Clients��$
��Left=�$��	31,86,0,0q�$	��Top=� J� RenderTransformOrigin$ -7.195,0.492&�$	��155��$��11(�$
��Bold"��� -   $ 
LblProduct��$��Products��$
��Left=�$��
207,86,0,0q�$	��Top=�$ -7.195,0.492&�$	��155��$��11(�$
��Bold"��� -   $ LblItems��$��Items��$
��Left=�$��
390,86,0,0q�$	��Top=�$ -7.195,0.492&�$	��454��$��11(�$
��Bold"�$��3��