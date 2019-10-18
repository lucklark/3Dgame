首先相对于之前上次的实验中按飞碟每段时间位置更新实现，这次则直接采用加入重力以及初速度的方式来进行改进，关键区别在于更新函数实现，具体如下：
```csharp
public override void Update () {
		gameobject.GetComponent<Rigidbody>().velocity = power / 35 * start_vector;
		gameobject.GetComponent<Rigidbody>().useGravity = true;
}
```
即通过Rigidbody来设定重力。
然后对于适配器模式的实现则如下：
```csharp
public class ActionManagerAdapter : MonoBehaviour, IActionManager {

	public FlyActionManager action_manager;
	public PhysisFlyActionManager phy_action_manager;
	public void playDisk(GameObject disk, float angle, float power,bool isPhy) {
		if(isPhy) {
			phy_action_manager.UFOFly(disk, angle, power);
		} else {
			action_manager.UFOFly(disk, angle, power);
		}
	}
	void Start () {
		action_manager = gameObject.AddComponent<FlyActionManager>() as FlyActionManager;
		phy_action_manager = gameObject.AddComponent<PhysisFlyActionManager>() as PhysisFlyActionManager;
	}
}
```
IActionManager接口为对应输入的运行飞碟及其状态以及是否采用物理机制或者通过运动轨迹规定。其适配器类有两种对应的实现方法。

视频见主目录下readme
