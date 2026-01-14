package workinghours

type WorkingHours struct {
    Normal  float64 //capital letter : public member
    Short   float64
    Long    float64
}

func Get() *WorkingHours{
    var w = new(WorkingHours)
    w.Normal = 8.0
    w.Short = 4.0
    w.Long = 12.0
    return w 
}