open canopy
open runner
open System
open Respawn

start firefox
pin FullScreen

let ResetTheDatabase _ =
    let testCheckpoint = new Checkpoint()
    testCheckpoint.TablesToIgnore <- 
        [|"ClusterGroup";
        "Cluster";
        "VolunteerType";
        "ResourceType";
        "VolunteerType";
        "Organization";
        "Person";
        "webpages_Membership";
        "webpages_Roles";
        "webpages_OAuthMembership";
        "webpages_UsersInRoles";
        "User"|]
    testCheckpoint.Reset("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ChrisisCheckin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Wait()


once( fun _ ->
    ResetTheDatabase()
)

"Create a Request" &&& fun _ ->
    Login.LoginAdministrator()
    Header.ClickRequests()
    Requests.CreateNewRequest "3/1/18" "At the river" "We need sandbags"
    Requests.AssertDescriptionExists "We need sandbags"

//run all tests
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()
