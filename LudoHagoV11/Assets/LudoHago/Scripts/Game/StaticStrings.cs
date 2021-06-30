namespace AssemblyCSharp
{
	public static class StaticStrings
	{

		//public static string localaddress = "http://localhost/hagotick/";
		public static string localaddress = "https://hogotickmadeinindialudo.online/";
		public static string winnerprizeurl = localaddress + "sendwinningamount.php";
		public static string getrefcode = localaddress + "gerefcode.php";
		public static string urllogin = localaddress + "login.php";
		public static string urlregister = localaddress + "registration.php";
		public static string totalGameplayed = localaddress + "playergamaplaycount.php";
		public static string Sendkwinnergaemtypedata = localaddress + "winningcountdata.php";
		public static string Sendkloosergaemtypedata = localaddress + "Sendkloosergaemtypedata.php";
		public static string urlbal = localaddress + "checkbal.php";
		public static string urlbid = localaddress + "bidamountsend.php";
		public static string SesndGameplayedData = localaddress + "totalgameplayeduser.php";
		public static string totalwinningamount = localaddress + "totalwinningamount.php";
		public static string gamecount = localaddress + "gamecount.php";
		public static string gamejoinbyidtypcount = localaddress + "joinbyidtype.php";
		public static string withdraw = localaddress + "withdraw.php";
		public static string withdrawpaytm = localaddress + "withdrawpaytm.php"; 
		public static string forgetpassword = localaddress + "forgetpassword.php";
		public static string banktransition = localaddress + "bankhistory.php";
		public static string otpsms = localaddress + "Otpsms.php";
		public static string checkotp = localaddress + "checkotp.php";
		public static string paymentgateway = localaddress + "game";
		public static string Whatsapphelp = "https://wa.link/ptvnei";
		public static string AndroidPackageName = "com.ludo.ludohago";
		public static string ITunesAppID = "11111111111";

		// Notifications
		public static string notificationTitle = "Ludo Hago";
		public static string notificationMessage = "Get your FREE fortune spin!";

		// Game configuration
		public static float WaitTimeUntilStartWithBots = 1.0f;
		// Time in seconds. If after that time new player doesnt join room game will start with bots

		// Services configration IDS
		public static string PlayFabTitleID = "55A5E";
		public static string PhotonAppID = "94fd1090-01a3-4c8e-a8e0-4ff01ade9638";
		public static string PhotonChatID = "de1331fb-ddff-49fd-abc8-acd3177e9840";



		// Facebook share variables
		public static string facebookShareLinkTitle = "I'm playing Ludo Hago !. Available on Android and iOS.";

		// Share private room code
		public static string SharePrivateLinkMessage = "Join me in Ludo Hago . My PRIVATE ROOM CODE is:";
		public static string SharePrivateLinkMessage1 = "Join me in Ludo Hago . My REFERRAL CODE is:";
		public static string SharePrivateLinkMessage2 = "Download Ludo Hago  from:";
		public static string ShareScreenShotText = "I finished game in Ludo Hago . It's my score :-) Join me and download Ludo Masters:";


		// Initial coins count for new players
		// When logged as Guest
		public static int initCoinsCountGuest = 0;
		//When logged via Facebook
		public static int initCoinsCountFacebook = 0;
		//When logged as Guest and then link to Facebook
		public static int CoinsForLinkToFacebook = 0;

		// Unity Ads - reward coins count for watching video
		public static int rewardForVideoAd = 0;

		// Facebook Invite variables
		public static string facebookInviteMessage = "Come play this great game!";
		public static int rewardCoinsForFriendInvite = 0;
		public static int rewardCoinsForShareViaFacebook = 0;

		// String to add coins for testing - To add coins start game, click "Edit" button on your avatar and put that string
		// It will add 1 000 000 coins so you can test tables, buy items etc.
		public static string addCoinsHackString = "Cheat:AddCoins";



		// Hide Coins tab in shop (In-App Purchases)
		public static bool hideCoinsTabInShop = false;
		public static string runOutOfTime = "ran out of time";
		public static string waitingForOpponent = "Waiting for your opponent";
		public static string refcode = GameManager.Instance.refcode;

		// Other strings
		public static string youAreBreaking = "You start, good luck";
		public static string opponentIsBreaking = "is starting";
		public static string IWantPlayAgain = "I want to play again!";
		public static string cantPlayRightNow = "Can't play right now";

		// Players names for training mode
		public static string offlineModePlayer1Name = "Player 1";
		public static string offlineModePlayer2Name = "Player 2";

		// Photon configuration
		// Timeout in second when player will be disconnected when game in background
		public static float photonDisconnectTimeout = 900.0f;
		// In game scene - its better to don't change it. Player that loose focus on app will be immediately disconnected
		public static float photonDisconnectTimeoutLong = 900.0f;
		// In menu scene etc.

		// Bids Values
		public static int[] bidValues = new int[] { 25, 50, 100, 200, 300, 400, 500, 1000 };
		public static string[] bidValuesStrings = new string[] {
			
			"25",
			"50",
			"100",
			"200",
			"300",
			"400",
			"500",
			"1000"

		};

		public static bool isFourPlayerModeEnabled = true;

		// Settings PlayerPrefs keys
		public static string SoundsKey = "EnableSounds";
		public static string VibrationsKey = "EnableVibrations";
		public static string NotificationsKey = "EnableNotifications";
		public static string FriendsRequestesKey = "EnableFriendsRequestes";
		public static string PrivateRoomKey = "EnablePrivateRoomRequestes";
		public static string PrefsPlayerRemovedAds = "UserRemovedAds";


		// Standard chat messages
		public static string[] chatMessages = new string[] {
			"Please don't kill",
			"Play Fast",
			"I will eat you",
			"You are good",
			"Well played",
			"Today is your day",
			"Hehehe",
			"Unlucky",
			"Thanks",
			"Yeah",
			"Remove Blockade",
			"Good Game",
			"Oops",
			"Today is my day",
			"All the best",
			"Hi",
			"Hello",
			"Nice move"
		};

		// Additional chat messages
		// Prices for chat packs
		public static int[] chatPrices = new int[] { 1000, 5000, 10000, 50000, 100000, 250000 };
		public static int[] emojisPrices = new int[] { 1000, 5000, 10000, 50000, 100000 };

		// Chat packs names
		public static string[] chatNames = new string[] {
			"Motivate",
			"Emoticons",
			"Cheers",
			"Gags",
			"Laughing",
			"Talking"
		};

		// Chat packs strings
		public static string[][] chatMessagesExtended = new string[][] {
			new string[] {
				"Never give up",
				"You can do it",
				"I know you have it in you!",
				"You play like a pro!",
				"You can win now!",
				"You're great!"
			},
			new string[] {
				":)",
				":(",
				":o",
				";D",
				":P",
				":|"
			},
			new string[] {
				"Keep it going",
				"Go opponents!",
				"Fabulastic",
				"You're awesome",
				"Best shot ever",
				"That was amazing",
			},
			new string[] {
				"OMG",
				"LOL",
				"ROFL",
				"O'RLY?!",
				"CYA",
				"YOLO"
			},
			new string[] {
				"Hahaha!!!",
				"Ho ho ho!!!",
				"Mwhahahaa",
				"Jejeje",
				"Booooo!",
				"Muuuuuuuhhh!"
			},
			new string[] {
				"Yes",
				"No",
				"I don't know",
				"Maybe",
				"Definitely",
				"Of course"
			}
		};

	}
}

