using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCameraController : InputController
{
    public GameObject target;
    float xAxis,yAxis;
    float distance;
    
    void Start()
    {
        if(target == null)Debug.LogError("Default target is missing");
        ChangeTarget(target.transform);
    }

    public override void Update()
    {
        base.Update();
    }

    public void ChangeTarget(Transform target) {
        this.target = target.gameObject;
        // this.transform.position = target.position;
        transform.position = target.transform.position + (transform.position - target.transform.position).normalized * 6f;
        transform.parent = target;

    }


    /*
        target.position retrieves the position of the target object.
        Quaternion.Euler(y, x, 0) creates a rotation represented by Euler angles (y, x, 0) in degrees. y and x are the angles that control the camera's up and right rotation, respectively.
        Vector3.forward is a constant vector pointing forward along the z-axis.
        Quaternion.Euler(y, x, 0) * Vector3.forward rotates the forward vector by the specified Euler angles. The result is a vector pointing in the direction the camera should be facing.
        target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) calculates the position of the camera by subtracting the rotated forward vector from the position of the target. This places the camera at a certain distance from the target in the direction specified by the rotated forward vector.
        transform.position = target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) sets the position of the camera to the calculated position.
        So in essence, this line of code rotates the camera around the target object based on the angles y and x and sets the camera's position so that it is distance units away from the target in the direction specified by the rotated forward vector.
    */
    /*
        target.position ανακτά τη θέση του αντικειμένου-στόχου.
        Quaternion.Euler(xAxis, yAxis, 0) δημιουργεί μια περιστροφή που αντιπροσωπεύεται από τις γωνίες Euler (xAxis, yAxis, 0) σε μοίρες. xAxis και yAxis είναι οι γωνίες που ελέγχουν την περιστροφή της κάμερας προς τα πάνω και προς τα δεξιά, αντίστοιχα.
        Το Vector3.forward είναι ένα σταθερό διάνυσμα που δείχνει προς τα εμπρός κατά μήκος του άξονα z.
        Το Quaternion.Euler(xAxis, yAxis, 0) * Vector3.forward περιστρέφει το διάνυσμα προς τα εμπρός κατά τις καθορισμένες γωνίες Euler. Το αποτέλεσμα είναι ένα διάνυσμα που δείχνει προς την κατεύθυνση που πρέπει να κοιτάζει η κάμερα.
        target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) υπολογίζει τη θέση της κάμερας αφαιρώντας το περιστρεφόμενο διάνυσμα forward από τη θέση του στόχου. Αυτό τοποθετεί την κάμερα σε ορισμένη απόσταση από το στόχο προς την κατεύθυνση που καθορίζεται από το περιστρεφόμενο διάνυσμα forward.
        transform.position = target.position - (Quaternion.Euler(y, x, 0) * Vector3.forward * distance) θέτει τη θέση της κάμερας στην υπολογισμένη θέση.
        Έτσι, στην ουσία, αυτή η γραμμή κώδικα περιστρέφει την κάμερα γύρω από το αντικείμενο-στόχο με βάση τις γωνίες y και x και θέτει τη θέση της κάμερας έτσι ώστε να απέχει μονάδες απόστασης από το στόχο προς την κατεύθυνση που καθορίζεται από το περιστρεφόμενο διάνυσμα forward.

Translated with www.DeepL.com/Translator (free version)
    */

    protected override void MoveObject()
    {
        distance += MouseInput() * 0.1f;
        distance = Mathf.Clamp(distance, 3,10);
        yAxis += KeyboardInput().z;
        xAxis -= KeyboardInput().x;
        yAxis = Mathf.Clamp(yAxis,-60,+60);//limit the rotation of Y to -60 and +60
        transform.LookAt(target.transform.position);
        transform.position = target.transform.position - Quaternion.Euler(yAxis, xAxis, 0) * Vector3.forward * distance;

    }
}
