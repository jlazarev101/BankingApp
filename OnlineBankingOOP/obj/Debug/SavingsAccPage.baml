   M S B A M L   `   `   `  ????K  GOnlineBankingOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnlineBankingOOPOnlineBankingOOP  5   	   %    OnlineBankingOOP.SavingsAccPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:OnlineBankingOOP     5   	     ? Title$  Savings Account??5   	   $	??539??6!   $	??363??6.    ? 
ResizeMode$ NoResize=?6:    ? WindowStyle$
 None=?6P    ? WindowStartupLocation$ CenterScreen=?6c   .??5	      ?? -   5        .+?5
   
   o? $??20??6   $	??363??6   $
??Left=?6'   $??Center=?6B    J? OpacityMask ?	#FF3737BA???	#FF141C3F???	#FF19F0B76?   ?? 5   
   -   5         ??Name$ transactionsLbl??5      $??Account Transactions??6)    ?? Left$ 83??6H   
 ?? Top$	 254??6Y   $
??Left=?6j   $??Center=?6?   $
??Bold"?6?   $??14(?6?   ?? 5   
   $	??153??6   $	??363??6   $??Center=?6*   $	??Top=?6G   $ 76??6_   $ -1??6o   ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&   	 ?? 
StartPoint$	 0.5,0&?67   .??5      ? 
 ? Color$
 Black??6#   ? 5      $
 	#FF49F616??6#    ? Offset$ 1Q?65   5      .+?5      ?? -   5        $ 
Currentlbl??5      $??SAVINGS ACCOUNT  BALANCE??6(   $ 60??6K   $	 -45??6\   $
??Bold"?6m   $??16(?6   $
??Left=?6?   $	??Top=?6?   ???	#FF0C0C0C6?   ?? 5      -   5        $ lblSavingsBal??5      $??addBalanceHere??6+   $	 108??6D   $ 48??6V   $
??Left=?6f   $??Center=?6?   $??22(?6?   $
??Bold"?6?   5      ?? 5   
   $??34??6   $	 476??6   $??38??6-   $??/Images/gb.jpg??68   $ 8??6P   $
??Left=?6`   $	??Top=?6{   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dgv??5      $	??160??6    $	 294??6-   $	??362??6>    J? RenderTransformOrigin$ 0.582,0.379&?6J   $??Center=?6n   $	??Top=?6?   ?? 5   
   -   5        $ 48??5      $
??Wrap=?6%   $
??Home??69   $	 483??6E   $
??Bold"?6V   $??15(?6h   $ 0.49,-0.249&?6v   $
??Left=?6?   $	??Top=?6?    ? Cursor$
 Hand??6?   ?? 5   
   -   5         ??Name$ 	btnUpdate??5      $??Update??6$   $	 243??65   $	 256??6G   $	??110??6X   $??27??6d   $
??Bold"?6?   ???	#FF44E515$
??Left=?6?   $??Center=?6?   5      5      