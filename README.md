Cosa ho fatto:
**Ho tolto gli underscore dalle variabili locali dentro le funzioni**
**Ho sistemato le cartelle**
Ho tolto CameraFollows. Ora uso la Cinemachine(provando a usare una Timeline).
Nel PlayerController : Ho usato gli Eventi. In Awake, il controller si "iscrive" all'evento OnDeath.
Quando il Player muore, viene chiamata automaticamente DisableMovement. Ho  aggiunto OnDestroy(),iscrivendomi e disiscrivendomi.
Il movimento era scritto dentro FixedUpdate.Ho creato Move().Usavo Time.deltaTime dentro FixedUpdate, adesso l'ho cambiato con Time.fixedDeltaTime.
Nel LifeController: Ho aggiunto IDamageable,OnDeath e OnHealthChange(Il LifeController ora è non sa se esiste una UI, un suono. Lui lancia l'evento e chiunque sia interessato reagisce.
Alcune variabili erano pubbliche , adesso sono private ma ho aggiunto le Proprierty.
Nel metodo Die(), ora chiamo l' AudioManager.
Nel PlayerAnimation : Prima controllavo nell Update se la vita fosse sotto lo zero. Ora si attiva solo quando LifeController lancia l'evento OnDeath.
Prima si occupava anche del movimento, azzerare la velocita ect.. ora se ne occupa il PlayerController.
Prima usavo direction.x != 0 ect.. ora ho messo direction.sqrMagnitude.Come per il controller, ho aggiunto OnDestroy con il -= PlayDeathAnimation.
**Ho messo [SerializeField] le stringhe che erano private.**
Nell'Enemy: Ora è una "Classe Padre". Il BossEnemy eredita da qui. Rimossol'Update. Ora il nemico muore solo quando il LifeController lancia l'evento OnDeath, chiamando il metodo HandleDeath.
Prima il nemico cercava il LifeController del giocatore. Ora usa l'IDamageable.
Nel BossEnemy: Ora eredita da Enemy. Gli ho aggiunto una UI(appare solo quando si inizia a muovere).**Ho tolto la parentesi in più.**
**Ed ho messo quel danno "magico" come variabile in ispector.**
Nel PickUp: **Prima prendevo l'oggetto che era a terra e lo mettevo sul al Player, ora la istanzio.** Ho levato il spegnere il Collider e Rigidbody.
Nel Gun: **Prima nell'Update usavo il FindGameObjectsWithTag. Ora utilizzo il GameManager per vedere i nemici.**
Ho invertito l'ordine nel Update. Prima controllo IfCanShoot(), e poi avvio la ricerca del nemico. Ho aggiunto un FirePoint.
Prima metteva Gun la velocità al Bullet, ora invece lo chiamo e lui sa come andare. **Ho aggiunto transform.up.**
Nel Bullet: Cerca IDamageable. Ho rimosso l'Update. Uso Inizialize per dare velocità.
Nello SpawnEnemy:Ho dato un limite massimo di nemici che possono esserci in scena.Invece di usare una variabile locale mi affido al  GameMangager.
Nell'Hearth : Ho messo un controllo , che se la vita del Player è già al massimo l'oggetto non viene utilizzato.
Ho eliminato Sound ed ho creato AudioManager,ora qualsiasi script può chiamare l'audio.
Aggiunte:
GameManager: Mantengo una lista di nemici. E' un Singleton.
SpotLightManager: Una specie di lanterna che diminuisce costantemente la sua luce.Si iscrive all'evento di LightGem.
Usa Action per far aggiornare la UI.
LightGem: L'item che aumenta la luce. Messo l'evento così SpotLightManager ci si può iscrivere.
WinManager: Gestisce il panel di vittoria. Invece che fermare il tempo, ho scelto di rallentarlo(mi piaceva di più).
Si iscrive all'evento OnDeath del Boss. Quando il Boss dà il segnale il WinManager si attiva.
Nello Start disattivo il pannello(faccio sempre così perchè se lo disattivo in ispector poi in game non me lo riattiva più).
Come per altri script mi disiscrivo dall'evento.
LoseManager: Qua ho bloccato direttamente perchè mi da più senso di sconfitta.Punta alla vita del Player.
MainMenuManager: Rimetto la velocità normale.Invece di scrivere dei nomi dentro la LoadScene, ho usato delle variabili.
Ho separato NewGame() e Restart(), perchè all'inizio pensavo di usare i salvataggi e che NewGame() facesse proprio una nuova partita.
Ma si è rivelato molto più complicato e quindi ho rinunciato. Ma ho voluto comunque lasciarli separati perchè da più senso di ordine.
EnemyLoot: Un sistema di loot per gli Heath e LightGem. Uso il return cosicchè non possano spawnare più oggetti.
Guarda anche lui all'evento OnDeath. Uso Random.Range per fare la chance di drop. Anche qua mi iscrivo e disiscrivo dall'evento.
UI_HealthBar: La barra aspetta il segnale OnHealthChange.Dato che la vita è in Int ho dovuto convertirla in Float per fare la barra con FillAmount.
UI_BossHealthBar: Come sopra.
UI_LightBar: Anche qui ho usato lo stesso schema. Quando in SpotLightManager la luce cala in Update manda un segnale, la UI lo coglie e aggiorna la barra.
