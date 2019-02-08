using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUtil
{
    //캐릭터를 목적지까지 이동시키는 함수 
    public static float MoveFrame(CharacterController controller, Vector3 target, float moveSpeed, float rotateSpeed)
    {
        Transform t = controller.transform;
        Vector3 dir = target - t.position;
        Vector3 dirXZ = new Vector3(dir.x, 0.0f, dir.z);
        Vector3 targetPos = t.position + dirXZ;
        Vector3 framePos = Vector3.MoveTowards(t.position, targetPos, moveSpeed * Time.deltaTime);

        controller.Move(framePos - t.position + Physics.gravity);//중력 추가했으니까 밑으로 내려가면 밑으로 캐릭터가 내려갈 거임 

        //회전도 넣어 줌 
        RotateToDir(t, target, rotateSpeed);

        return Vector3.Distance(framePos, targetPos);
    }

    //회전 시켜주는 함수 
    public static void RotateToDir(Transform self, Vector3 target, float rotateSpeed)
    {
        Vector3 dir = target - self.position;
        Vector3 dirXZ = new Vector3(dir.x, 0.0f, dir.z);
        if (dirXZ == Vector3.zero)
            return;
        self.rotation = Quaternion.RotateTowards(self.rotation, Quaternion.LookRotation(dirXZ), rotateSpeed * Time.deltaTime);
    }
}