   M S B A M L   `   `   `  ????K  GOnlineBankingOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnlineBankingOOPOnlineBankingOOP  5   	   %    OnlineBankingOOP.CurrentAccPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:OnlineBankingOOP     5   	     ? Title$  Current Account??5   	   $	??539??6!   $	??363??6.    ? 
ResizeMode$ NoResize=?6:    ? WindowStyle$
 None=?6P    ? WindowStartupLocation$ CenterScreen=?6c   .??5	      ?? .+?5
   
   o? $??20??6   $	??363??6   $
??Left=?6'   $??Center=?6B    J? OpacityMask ?	#FF3737BA???	#FF141C3F???	#FF19F0B76?   ?? 5   
   -   5         ??Name$ transactionsLbl??5      $??Account Transactions??6)    ?? Left$ 88??6H   
 ?? Top$	 241??6Y   $
??Left=?6j   $??Center=?6?   $
??Bold"?6?   $??14(?6?   ?? 5   
   -   5        $	??150??5      $	??363??6   $ 77??6*   $??Center=?6:   $	??Top=?6W   ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&   	 ?? 
StartPoint$	 0.5,0&?67   .??5      ? 
 ? Color$
 Black??6#   ? 5      $
 	#FF16BDF6??6#    ? Offset$ 1Q?65   5      .+?5      ?? -   5        $ 
Currentlbl??5      $??CURRENT ACCOUNT  BALANCE??6(   $ 59??6K   $	 -40??6\   $
??Bold"?6m   $??16(?6   $??Center=?6?   $	??Top=?6?   ???	#FF1110106?   ?? 5      -   5        $ lblCurrentBal??5      $??addBalanceHere??6+   $	 113??6D   $ 55??6V   $
??Left=?6f   $??Center=?6?   $??22(?6?   $
??Bold"?6?    J? RenderTransformOrigin$ 0.255,0.602&?6?   5      ?? 5   
   $??34??6   $	 476??6   $??38??6-   $??/Images/gb.jpg??68   $ 7??6P   $??Center=?6`   $	??Top=?6}   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dgv??5      $	??164??6    $	 275??6-   $	??363??6>   $??Center=?6J   $	??Top=?6g   ?? 5   
   -   5        $ 47??5      $
??Wrap=?6%   $
??Home??69   $	 483??6E   $
??Bold"?6V   $??15(?6h   $ 0.49,-0.249&?6v   $??Center=?6?   $	??Top=?6?    ? Cursor$
 Hand??6?   ?? 5   
   -   5         ??Name$ 	btnUpdate??5      $??Update??6$   $	 243??65   $	 242??6G   $	??110??6X   $??27??6d   ???	#FF14ACE1$
??Bold"?6?   5      5      