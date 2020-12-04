﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in "PUN Basic tutorial" to handle typical game management requirements
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;
using System.Collections.Generic;

using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.PunBasics
{
#pragma warning disable 649
    
    /// <summary>
    /// Game manager.
    /// Connects and watch Photon Status, Instantiate Player
    /// Deals with quiting the room and the game
    /// Deals with level loading (outside the in room synchronization)
    /// </summary>
    public class GameManager : MonoBehaviourPunCallbacks
    {

		#region Public Fields
      
		static public GameManager Instance;
       
        #endregion 
        #region Private Fields
        [Header("Vehicles")]
        private GameObject instance;


        [Header("SpawnPoints")]
        [Tooltip("Spawn Points")]
        public Transform[] SpawnPoints;
        int SpawnPoint = 0;
        public int PlayerPos;

        [Tooltip("The prefab to use for representing the player")]
        [SerializeField]
        private GameObject playerPrefab;
        private GameObject RandomPrefab;

        [Header("Map Parts")]
        public List<GameObject> liGoSpawn = new List<GameObject>();
        public GameObject LevelGen;
        #endregion

        [Header("Colours")]
        public GameObject ColorPalletes;

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
		{
            Debug.Log("Player List: " + PhotonNetwork.PlayerList + " --- " + "Current Room:" + PhotonNetwork.CurrentRoom + " ---- " + "Number of Rooms: " + PhotonNetwork.CountOfRooms);
            //DontDestroyOnLoad(gameObject);
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(LevelGen.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(LevelGen.name, new Vector3(0, 0, 150), Quaternion.identity, 0);
                Debug.Log("This is Master");
                PhotonNetwork.Instantiate(ColorPalletes.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
            }


            Instance = this;

			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene(0);

				return;
			}

            if (playerPrefab == null)
            { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

                Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {

                if (PlayerManager.LocalPlayerInstance == null)
                {
                    //SpawnPoint++;
                    SpawnPoint = Random.Range(0, SpawnPoints.Length);
                    //Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("-Race"))
                    {
                        int startPos = PhotonNetwork.LocalPlayer.GetPlayerNumber();
                        PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[startPos].transform.position, Quaternion.identity, 0);
                    }
                    if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("-WinScene"))
                    {
                        PlayerPos = PlayerPrefs.GetInt("PlayerPos");
                        PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoints[PlayerPos].transform.position, transform.rotation, 0);
                    }

                }
                else
                {

                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }

            }

            //if(SceneManager.GetActiveScene() == Scene(3))
        }


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity on every frame.
        /// </summary>
        void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}

            
		}

        #endregion


        #region Photon Callbacks

            /// <summary>
            /// Called when a Photon Player got connected. We need to then load a bigger scene.
            /// </summary>
            /// <param name="other">Other.</param>
        public override void OnPlayerEnteredRoom( Player other  )
		{
			Debug.Log( "OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

			if ( PhotonNetwork.IsMasterClient )
			{
                
                Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom
                
                //LoadArena();
                
			}



            
        }

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public override void OnPlayerLeftRoom( Player other  )
		{
			Debug.Log( "OnPlayerLeftRoom() " + other.NickName ); // seen when other disconnects

			if ( PhotonNetwork.IsMasterClient )
			{
				Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom

				//LoadArena(); 
			}
		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public override void OnLeftRoom()
		{
			SceneManager.LoadScene(1);
		}

		#endregion

		#region Public Methods

		public void LeaveRoom()
		{
            PhotonNetwork.Disconnect();

        }

		public void QuitApplication()
		{
			Application.Quit();
            LeaveRoom();
        }

		#endregion

		#region Private Methods

		void LoadArena()
		{
			if ( ! PhotonNetwork.IsMasterClient )
			{
                
                Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}
            else
            {
            PhotonNetwork.Instantiate(LevelGen.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
               
                PhotonNetwork.Instantiate(ColorPalletes.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
            }
			//Debug.LogFormat( "PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount );
            
            //PhotonNetwork.LoadLevel("PunBasics-Room for "+PhotonNetwork.CurrentRoom.PlayerCount);
		}

		#endregion

	}

}