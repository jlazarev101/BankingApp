   M S B A M L   `   `   `  ????K  GOnlineBankingOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnlineBankingOOPOnlineBankingOOP  5   	   #    OnlineBankingOOP.TransferPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:OnlineBankingOOP     5   	     ? Title$  Transfer??5   
   $	??539??6   $	??363??6(    ? 
ResizeMode$ NoResize=?64    ? WindowStyle$
 None=?6J    ? WindowStartupLocation$ CenterScreen=?6]   .??5	      ?? ???	#FFF6F1F1.+?5
   
   o? $??20??6   $	??363??6   $
??Left=?6'   $??Center=?6B    J? OpacityMask ?	#FF3737BA???	#FF141C3F???	#FF19F0B76?   ?? 5   
   -   5         ??Name$ 
Currentlbl??5      $??TRANSFERS   ??6$    ?? Left$	 129??6;   
 ?? Top$ 33??6M   $
??Bold"?6]   $??16(?6o   $
??Left=?6}   $??Center=?6?   ???	#FF120909$	??105??6?   ??6?   Z? 6?   ?? 5   
   $??34??6   $	 471??6   $??38??6-   $??/Images/gb.jpg??68   $ 8??6P   $
??Left=?6`   $	??Top=?6{   ?? 5   
   -   5        $	??371??5      $	??363??6   $??Center=?6*   $ 69??6G   $	??Top=?6W   ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&   	 ?? 
StartPoint$	 0.5,0&?67   .??5      ? 
 ? Color$
 Black??6#   ? 5      $
 	#FF4CA380??6#    ? Offset$ 1Q?65   5      .+?5      ?? -   5         ??Name$ 	cmbSender??5      $ 39??6*   $ 52??6;   $	??295??6K   $??34??6W   $
??Left=?6c   $	??Top=?6~   ?? 5      $??From (Account)??6   $ 39??6-   $ 18??6>   $??29??6N   $	??128??6Z   $
??Bold"?6f   $??16(?6x    J? RenderTransformOrigin$ 0.576,-0.918&?6?   $
??Left=?6?   $	??Top=?6?   ???	#FFFAEBEB6?   ?? 5      $??To (Account)??6   $ 39??6+   $	 128??6<   $
??Bold"?6M   $??16(?6_   $
??Left=?6m   $	??Top=?6?   ???	#FFFAF0F06?   ?? 5      $??Amount  ??6   $ 39??6'   $	 217??68   $
??Bold"?6I   $??16(?6[   $
??Left=?6i   $	??Top=?6?   ???	#FFFAEDED6?   ?? 5      -   5         ??Name$ 	txtAmount??5      $ 39??6)    ?? TextWrapping$
 Wrap=?6:   $	 253??6O   $	??295??6`   $??34??6l   $
??Left=?6x   $	??Top=?6?   ?? 5      -   5         ??Name$ btnConfirmTransfer??5      $??Confirm    ??61   $	 103??6G   $	 327??6Y   $??35??6j   $	??177??6v   ???	#FF1D1918???	#FF19F0B7$
??Bold"?6?   $??16(?6?   $
??Left=?6?   $	??Top=?6  ?? 5      -   5        $ cmbReceiver??5      $ 39??6,   $	 168??6=   $	??295??6N   $??34??6Z   $??Center=?6f   $	??Top=?6?   5      ?? 5   
   -   5        $ 48??5      $
??Wrap=?6%   $
??Home??69   $	 478??6E   $
??Bold"?6V   $??15(?6h   $ 0.49,-0.249&?6v   $
??Left=?6?   $	??Top=?6?    ? Cursor$
 Hand??6?   5      5      