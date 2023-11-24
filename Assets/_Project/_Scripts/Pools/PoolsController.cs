namespace _Project._Scripts.Pools
{
    public class PoolsController
    {
        private PoolsManager _poolsManager;

        public PoolsController()
        {
            _poolsManager = new PoolsManager();
        }
        
        public PoolObjects<PoolableObject> CreatePool(string name,Projectile projectile)
        {
            return _poolsManager.CreatePool(name, projectile);
            
        }
    }
}