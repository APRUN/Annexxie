namespace Annexxie.Model
{
    public class Staff
    {
        int vStaffId, vRoleId, vSalary;
		DateTime vDateTime;

		public Staff(int staffId, int roleId, int salary)
        {
            vStaffId = staffId;
            vRoleId = roleId;
            vSalary = salary;
        }
		public Staff(int staffId, int roleId, int salary, DateTime datetime)
		{
			vStaffId = staffId;
			vRoleId = roleId;
			vSalary = salary;
            vDateTime = datetime;
		}

		public int StaffId { get => vStaffId; set => vStaffId = value; }
        public int RoleId { get => vRoleId; set => vRoleId = value; }
        public int Salary { get => vSalary; set => vSalary = value; }
    }
}
