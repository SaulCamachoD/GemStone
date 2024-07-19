using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Create EnemyProPlayer", fileName = "Enemigo", order = 0)]
public class EnemyProPlayer : EnemyCharacter

{
    private Animator _animator;
    private NavMeshAgent _agent;
    public void Initialize(NavMeshAgent agent, Animator animation)
    {
        _agent = agent;
        _animator = animation;
        if(_animator != null) _animator.SetBool("vivo" , true);
    }
    public override void EstadoIdle()
    {
        base.EstadoIdle();
        if(_animator !=null)_animator.SetFloat("velocidad", 0);
        if(_animator !=null)_animator.SetBool("atacando", false);
        _agent.SetDestination(_agent.transform.position);
        
        //UnityEngine.Debug.Log("Kieto");
    }
    public override void EstadoSeguir()
    {
        base.EstadoSeguir();
        if(_animator !=null)_animator.SetFloat("velocidad",1);
        if(_animator !=null)_animator.SetBool("atacando",false);
        _agent.SetDestination(target.transform.position);
        
        //UnityEngine.Debug.Log("siguiendo endo");
    }
    public override void EstadoAtacar()
    {
        
        base.EstadoAtacar();
        _agent.SetDestination(_agent.transform.position);
        _agent.transform.LookAt(target,Vector3.up);
        if(_animator !=null)_animator.SetFloat("velocidad",0);
        if(_animator !=null)_animator.SetBool("atacando",true);
    }
    public override void EstadoMuerto()
    {
        base.EstadoMuerto();
        if(_animator !=null)_animator.SetBool("vivo",false);
        _agent.enabled = false;
        
        //UnityEngine.Debug.Log("muriendo endo");
    }
    
}
