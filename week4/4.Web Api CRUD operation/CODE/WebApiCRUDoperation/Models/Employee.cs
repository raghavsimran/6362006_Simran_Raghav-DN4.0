public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; }
    public List<Skill> Skills { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string DeptName { get; set; }
}

public class Skill
{
    public string SkillName { get; set; }
}
