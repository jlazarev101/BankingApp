   M S B A M L   `   `   `  ????K  GOnlineBankingOOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnlineBankingOOPOnlineBankingOOP  5   	   %    OnlineBankingOOP.NewAccountPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:OnlineBankingOOP     5   	     ? Title$  New Account Page ??5   	   $	??539??6#   $	??363??60    ? 
ResizeMode$ NoResize=?6<    ? WindowStyle$
 None=?6R    ? WindowStartupLocation$ CenterScreen=?6e   .??5	      ?? $??0,0,0,4q?6   .+?5
   
   ?? -   5         ??Name$ lblTitleNewAccountPage??5
      $??Start a Savings Account??60    ?? Left$ 86??6R   
 ?? Top$ 20??6c   $
??Left=?6s   $??Center=?6?   $	??202??6?    J? RenderTransformOrigin$ 0.216,2.213&?6?   $??Microsoft YaHei)?6?   $
??Bold"?6?   $??16(?6  ?? 5   
   $??34??6   $ 4??6   $	 469??6,   $??38??6=   $??/Images/gb.jpg??6H   $
??Left=?6`   $	??Top=?6{   ?? 5   
   -   5        $ 41??5      $
??Wrap=?6%   $
??Home??69   $	 476??6E   $
??Bold"?6V   $??15(?6h   $ 0.49,-0.249&?6v    ? Cursor$
 Hand??6?   o? 5   
   $??20??6   $	??363??6   	 J? OpacityMask	 ?	#FF3737BA???	#FF141C3F???	#FF19F0B7$??Center=?6m   $??Center=?6?   ?? 5   
   -   5        
 ??Name$
 Canvas??5      $	??392??6!   $	??363??6.   $??Center=?6:   $ 56??6W   $	??Top=?6g   ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&    ?? 
StartPoint$ 0.5,0&?67   .??5      ?  ? Color$ Black??6#   ? 5      $ 	#FFDFE053??6#    ? Offset$ 1Q?65   5      .+?5      ?? -   5        $ lblNewAccPage??5      $??lblNewAccPage??6+   $ 72??6C   $ 56??6T   $	??291??6d   ???	#FFFAEEEE$
??Bold"?6?   $??16(?6?   $
??Left=?6?   $	??Top=?6?   ?? 5      $+??%You are opening a new Savings Account??6   $ 93??6D   $	 252??6U   $
??Bold"?6f   ???	#FFFAEDED$ 0.419,-0.206&?6?   $??Center=?6?   $	??Top=?6?   ?? 5      -   5         ??Name$ btnSubmitLogin??5      $!??Create New Savings Account ??6-   $	 125??6S   $	 341??6e   $	??202??6v   $
??Bold"?6?   ???	#FF19F0B7$??20??6?   $
??Left=?6?   $	??Top=?6?    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      ?? 5      $??Banking Details??6   $	 226??6.   $	 221??6@   $
??bold"?6Q   ???	#FFF6E00F$
??Left=?6z   $	??Top=?6?   ?? 5      -   5        $ 
lblInitDep??5      $??Initial Deposit??6(   $ 93??6B   $	 296??6S   $??Center=?6d   $	??Top=?6?   $
??Bold"?6?   ?? 5      -   5         ??Name$ 
txtInitDep??5      $	 204??6*    ?? TextWrapping$
 Wrap=?6<   $	 300??6P   $	??120??6a   $
??Left=?6m   $	??Top=?6?   5      ?? 5    
   -   5        $ lblClientNotice??5       $????    In this section, you can create new savings accounts. 
           We already have your Personal Details, 
    so all you will need to do is depositing any amount 
           to your new account and it is all set up.
    ??6)   $	 173??6)  $
??Left=?6:  $	??Top=?6U  $	??374??6m  $??14(?6y  $
??Bold"?6?  5"      5#      